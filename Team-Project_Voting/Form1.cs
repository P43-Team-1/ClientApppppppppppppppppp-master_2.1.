using System.Windows.Forms;
using static Team_Project_Voting.TitleVoiting;
using System.Drawing.Imaging;
namespace Team_Project_Voting
{

    public partial class Form1 : Form
    {
        private string login;
        public Form1()
        {
            InitializeComponent();
            label1.Text = "I am a label";
            Shown += Form1_Shown;
        }
        private void Setting_Click(object sender, EventArgs e)
        {
            
        }

        private void VoteItems()
        {

            TitleVoiting[] votingItems = new TitleVoiting[7];
            for (int i = 0; i < votingItems.Length; i++)
            {
                votingItems[i] = new TitleVoiting();
                votingItems[i].Background = PictrureMatrix(Properties.Resources.Знімок_екрана_2026_02_18_172853, 0.8f); ;
                votingItems[i].title = "Voting Item " + (i + 1);
                votingItems[i].Voted = "0 votes";
                flowLayoutPanel2.Controls.Add(votingItems[i]);
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
