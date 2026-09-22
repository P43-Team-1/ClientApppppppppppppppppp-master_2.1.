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
        public Voting()
        {
            InitializeComponent();
        }

        private void Voting_Load(object sender, EventArgs e)
        {
            label1.Text = "Welcome to the Voting System!\nI think this is a great idea!" +
    "\nMebombo\n and I'm excited to participate!\n Kommmmmmmmbo";
        }
    }
}
