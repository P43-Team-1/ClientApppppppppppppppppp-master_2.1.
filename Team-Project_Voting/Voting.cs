using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Team_Project_Voting
{
    public partial class Voting : Form
    {
        private readonly int _userId;
        private readonly ServerSpeaking _server = new ServerSpeaking();
        private readonly List<Options> _options = new List<Options>();
        private Options? _selectedOption;
        private bool _hasVoted;

        /// <summary>
        /// The option currently chosen by the user. Use this when saving a vote.
        /// </summary>
        public Options? SelectedOption => _selectedOption;

        public Voting(ServerSpeaking server, int voteId)
        {
            _userId = userId;
            InitializeComponent();
            label1.Size = new Size(400, 20);
            this.server = server;
            this.voteId = voteId;
        }

        private async void Voting_Load(object sender, EventArgs e)
        {
            var (title, options) = await server.GetVoteOptions(voteId);

            if (options == null)
            {
                MessageBox.Show("Не вдалося завантажити варіанти відповіді");
                this.Close();
                return;
            }

            label1.Text = title;

            foreach (var option in options)
            {
                var optionControl = new Options();
                optionControl.optionImage = Properties.Resources.Знімок_екрана_2026_02_18_172853;
                optionControl.optionText = option.Text;
                optionControl.Selected += Option_Selected;

                optionIds[optionControl] = option.Id;

                flowLayoutPanel1.Controls.Add(optionControl);
            }

            button1.Enabled = !_hasVoted;
            button1.Text = _hasVoted ? "Ви вже проголосували" : "Проголосувати";
        }

        private void Option_Selected(object? sender, EventArgs e)
        {
            if (_hasVoted)
            {
                return;
            }
            if (sender is not Options selectedOption)
            {
                return;
            }

            _selectedOption?.SetSelected(false);
            _selectedOption = selectedOption;
            _selectedOption.SetSelected(true);

            button1.Enabled = true;
        }

        private void label1_SizeChanged(object sender, EventArgs e)
        {
            int paddingBottom = 10;

            this.Height = label1.Bottom + paddingBottom;

            flowLayoutPanel1.Top += label1.Bottom;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (_selectedOption is null)
            {
                MessageBox.Show("Спочатку виберіть варіант.");
                return;
            }

            button1.Enabled = false;
            string response = await _server.Vote(_userId, _selectedOption.OptionId);
            if (response == "vote_success")
            {
                _hasVoted = true;
                foreach (Options option in _options)
                {
                    option.SetSelectionEnabled(false);
                }

                button1.Text = "Ви проголосували";
                await RefreshResults();
                return;
            }

            if (response == "vote_already_cast")
            {
                _hasVoted = true;
                foreach (Options option in _options)
                {
                    option.SetSelectionEnabled(false);
                }
                button1.Text = "Ви вже проголосували";
                await RefreshResults();
                return;
            }

            button1.Enabled = true;
            MessageBox.Show("Не вдалося зберегти голос. Спробуйте ще раз.");
        }

        private async Task RefreshResults()
        {
            ServerSpeaking.VoteInfo? vote = await _server.GetActiveVote(_userId);
            if (vote is null)
            {
                return;
            }

            foreach (Options option in _options)
            {
                ServerSpeaking.VoteOptionInfo? serverOption = vote.Options.FirstOrDefault(item => item.Id == option.OptionId);
                if (serverOption is not null)
                {
                    option.Percentage = serverOption.Percentage;
                }
            }
        }

        private async void btnVote_Click(object sender, EventArgs e)
        {
            if (_selectedOption == null)
            {
                MessageBox.Show("Оберіть варіант відповіді");
                return;
            }

            int optionId = optionIds[_selectedOption];
            bool success = await server.CastVote(voteId, optionId);

            if (success)
            {
                this.Close();
            }
        }
    }
    
}
