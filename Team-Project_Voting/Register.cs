using System;
using System.Linq;
using System.Windows.Forms;

namespace Team_Project_Voting
{
    public partial class Register : Form
    {
        ServerSpeaking server;
        public Register()
        {
            InitializeComponent();
            server = new ServerSpeaking();
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string login = textBox2.Text;
            string password = textBox3.Text;

            if (username == "" || login == "" || password == "")
            {
                MessageBox.Show("Заповніть всі поля!");
                return;
            }
            await server.Registration(login, password, username);
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Intentionally left empty — handler required by Designer
        }
    }
}
