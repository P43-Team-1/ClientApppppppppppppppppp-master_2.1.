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
        private Options? _selectedOption;

        /// <summary>
        /// The option currently chosen by the user. Use this when saving a vote.
        /// </summary>
        public Options? SelectedOption => _selectedOption;

        public Voting()
        {
            InitializeComponent();
            label1.Size = new Size(400, 20);
        }

        private void Voting_Load(object sender, EventArgs e)
        {
            label1.Text = "Welcome to the Voting System!\nI think this is a great idea!" +
    "\nMebombo\n and I'm excited to participate!\n Kommmmmmmmbo";
            Options[] options = new Options[4];
            for (int i = 0; i < options.Length; i++)
            {
                options[i] = new Options();
                options[i].optionImage = Properties.Resources.Знімок_екрана_2026_02_18_172853;
                options[i].optionText = "Option " + (i + 1);
                options[i].Selected += Option_Selected;
                flowLayoutPanel1.Controls.Add(options[i]);
            }
        }

        private void Option_Selected(object? sender, EventArgs e)
        {
            if (sender is not Options selectedOption)
            {
                return;
            }

            _selectedOption?.SetSelected(false);
            _selectedOption = selectedOption;
            _selectedOption.SetSelected(true);

            // A visible confirmation; the chosen object is also available via SelectedOption.
            Text = $"Voting — selected: {_selectedOption.optionText}";
        }

        private void label1_SizeChanged(object sender, EventArgs e)
        {
            int paddingBottom = 10;

            this.Height = label1.Bottom + paddingBottom;

            flowLayoutPanel1.Top += label1.Bottom;
        }

        private void Statistic_SizeChanged(object sender, EventArgs e)
        {
            int paddingBottom = 10;

            this.Height = Statistic.Bottom + Statistic.Height + paddingBottom;
        }
    }
}
