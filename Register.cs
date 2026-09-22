using System;
using System.Linq;
using System.Windows.Forms;
using Team_Project_Voting.Data;
using Team_Project_Voting.VoteMe;

namespace Team_Project_Voting
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string login = textBox2.Text;
            string password = textBox3.Text;

            if (username == "" || login == "" || password == "")
            {
                MessageBox.Show("Заповніть всі поля!");
                return;
            }

            using (var context = new VotingMenu())
            {
                // Перевіряємо, чи такий login вже існує
                var existingUser = context.Users.FirstOrDefault(u => u.Login == login);

                if (existingUser != null)
                {
                    MessageBox.Show("Користувач з таким логіном вже існує!");
                    return;
                }

                // Створюємо нового користувача
                var user = new User
                {
                    Username = username,
                    Login = login,
                    Password = password
                };

                context.Users.Add(user);
                context.SaveChanges();

                MessageBox.Show("Реєстрація успішна!");
                Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Intentionally left empty — handler required by Designer
        }
    }
}
