using System.Windows.Forms;
using static Team_Project_Voting.TitleVoiting;
using System.Drawing.Imaging;
namespace Team_Project_Voting
{

    public partial class Form1 : Form
    {
        private string login;
        private ServerSpeaking server;
        public Form1()
        {
            InitializeComponent();
            label1.Text = "I am a label";
            server = new ServerSpeaking();
            Shown += Form1_Shown;
        }
        private void Setting_Click(object sender, EventArgs e)
        {
            using var Settings = new Setting();       
            Settings.ShowDialog();
            VoteItems();
        }

        private async void VoteItems()
        {
            var votes = await server.GetVotes();

            if (votes == null)
            {
                MessageBox.Show("Не вдалося завантажити список голосувань");
                return;
            }

            flowLayoutPanel2.Controls.Clear();

            foreach (var vote in votes)
            {
                var item = new TitleVoiting();
                item.Background = PictrureMatrix(Properties.Resources.Знімок_екрана_2026_02_18_172853, 0.8f);
                item.title = vote.Title;
                item.VoteId = vote.Id;
                item.Voted = $"{vote.TotalVotes} votes";
                item.Server = server;

                flowLayoutPanel2.Controls.Add(item);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_Shown(object? sender, EventArgs e)
        {
            using var loginForm = new Login();

            if (loginForm.ShowDialog(this) != DialogResult.OK)
            {
                Close();
                return;
            }
            string Nick = loginForm.NickName;
            string Role = loginForm.Role;

            label2.BeginInvoke(() => { label2.Text = Nick; });
            if(Role == "Admin") { Setting.BeginInvoke(() => { Setting.Visible = true; }); }
            VoteItems();
        }

        private Image PictrureMatrix(Image image, float alpha)
        {
            Bitmap bitmap = new Bitmap(image);

            ColorMatrix matrix = new ColorMatrix();
            matrix.Matrix33 = alpha;

            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(matrix);
            Bitmap transperentImage = new Bitmap(bitmap.Width, bitmap.Height);

            using (Graphics g = Graphics.FromImage(transperentImage))
            {
                g.DrawImage(bitmap,
                    new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                    0, 0, bitmap.Width, bitmap.Height,
                    GraphicsUnit.Pixel, attributes);
            }
            image = transperentImage;
            return image;
        }
    }
}
