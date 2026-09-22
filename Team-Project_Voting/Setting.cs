using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Team_Project_Voting
{
    public partial class Setting : Form
    {
        private ServerSpeaking server;

        public Setting()
        {
            InitializeComponent();
            server = new ServerSpeaking();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            await server.CreateVote(textBox1.Text, GetChoices(), dateTimePicker1.Value.ToString("O"));
        }

        private string GetChoices()
        {
            string choices;
            string[] options = textBox2.Text
                .Split('\n')
                .Select(o => o.Trim())
                .Where(o => !string.IsNullOrEmpty(o))
                .ToArray();
            return string.Join("|", options);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.BeginInvoke(() => { textBox1.Text = "Назва голосування"; });
            textBox2.BeginInvoke(() => { textBox2.Text = "Варіанти відповіді(Кожна відповідь з нового рядка)"; });
            dateTimePicker1.BeginInvoke(() => { dateTimePicker1.Value = DateTime.Now; });
        }
    }
}
