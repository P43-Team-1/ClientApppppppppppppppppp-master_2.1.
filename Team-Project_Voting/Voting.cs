using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Team_Project_Voting
{
    public partial class Voting : Form
    {
        private Options? _selectedOption;
        private ServerSpeaking server;
        private int voteId;
        private Dictionary<Options, int> optionIds = new();
        private bool _hasVoted;

        public Options? SelectedOption => _selectedOption;

        public Voting(ServerSpeaking server, int voteId)
        {
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
                optionControl.OptionId = option.Id;
                optionControl.Selected += Option_Selected;

                optionIds[optionControl] = option.Id;

                flowLayoutPanel1.Controls.Add(optionControl);
            }
        }

        private void Option_Selected(object? sender, EventArgs e)
        {
            if (_hasVoted) return;
            if (sender is not Options selectedOption) return;

            _selectedOption?.SetSelected(false);
            _selectedOption = selectedOption;
            _selectedOption.SetSelected(true);

            Text = $"Voting — selected: {_selectedOption.optionText}";
        }

        private void label1_SizeChanged(object sender, EventArgs e)
        {
            int paddingBottom = 10;
            this.Height = label1.Bottom + paddingBottom;
            flowLayoutPanel1.Top += label1.Bottom;
        }

        private async void btnVote_Click(object sender, EventArgs e)
        {
            if (_selectedOption == null)
            {
                MessageBox.Show("Оберіть варіант відповіді");
                return;
            }

            btnVote.Enabled = false;
            int optionId = optionIds[_selectedOption];
            bool success = await server.CastVote(voteId, optionId);

            if (success)
            {
                _hasVoted = true;
                foreach (var opt in optionIds.Keys)
                {
                    opt.SetSelectionEnabled(false); // блокуємо подальший вибір
                }

                btnVote.Text = "Ви проголосували";
                await RefreshResults();
            }
            else
            {
                btnVote.Enabled = true;
            }
        }

        private async Task RefreshResults()
        {
            var (title, results) = await server.GetVoteResults(voteId);
            if (results == null) return;

            foreach (var optionControl in optionIds.Keys)
            {
                var match = results.FirstOrDefault(r => r.Id == optionControl.OptionId);
                if (match.Id != 0) 
                {
                    optionControl.Percentage = (decimal)match.Percentage;
                }
            }
        }
    }
}