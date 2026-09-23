
using System;
using System.Linq;
using System.Windows.Forms;

namespace Team_Project_Voting
{
    public partial class Login : Form
    {
        ServerSpeaking server;
        public string NickName { get; private set; }
        public string Role { get; private set; }
        public int UserId { get; private set; }
        public Login()
        {
            InitializeComponent();
             server = new ServerSpeaking();
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;
            string result = await server.Login(login, password);
            if (result != null) {
                string[] parts = result.Split(';');
                NickName = parts[0];
                Role = parts[1];
                if (!int.TryParse(parts[2], out int userId))
                {
                    MessageBox.Show("Сервер повернув некоректні дані користувача.");
                    return;
                }
                UserId = userId;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using var registerForm = new Register();
            registerForm.ShowDialog(this);
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
