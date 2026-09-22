namespace Team_Project_Voting
{
    partial class TitleVoiting
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            btnVoting = new Button();
            lblVoted = new Label();
            lblTitle = new Label();
            lblBackground = new PictureBox();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)lblBackground).BeginInit();
            SuspendLayout();
            // 
            // btnVoting
            // 
            btnVoting.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnVoting.Location = new Point(381, 130);
            btnVoting.Name = "btnVoting";
            btnVoting.Size = new Size(103, 29);
            btnVoting.TabIndex = 0;
            btnVoting.Text = "Голосувати";
            btnVoting.UseVisualStyleBackColor = true;
            btnVoting.Click += btnVoting_Click;
            // 
            // lblVoted
            // 
            lblVoted.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblVoted.AutoSize = true;
            lblVoted.Location = new Point(189, 134);
            lblVoted.Name = "lblVoted";
            lblVoted.Size = new Size(177, 20);
            lblVoted.TabIndex = 2;
            lblVoted.Text = "проголосувало ... людей";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F);
            lblTitle.Location = new Point(5, 14);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(263, 30);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "якась назва голосування";
            // 
            // lblBackground
            // 
            lblBackground.Dock = DockStyle.Fill;
            lblBackground.Location = new Point(0, 0);
            lblBackground.Name = "lblBackground";
            lblBackground.Size = new Size(497, 166);
            lblBackground.SizeMode = PictureBoxSizeMode.StretchImage;
            lblBackground.TabIndex = 4;
            lblBackground.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveBorder;
            panel1.Location = new Point(0, 163);
            panel1.Name = "panel1";
            panel1.Size = new Size(497, 3);
            panel1.TabIndex = 5;
            // 
            // TitleVoiting
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(lblTitle);
            Controls.Add(lblVoted);
            Controls.Add(btnVoting);
            Controls.Add(lblBackground);
            Name = "TitleVoiting";
            Size = new Size(497, 166);
            ((System.ComponentModel.ISupportInitialize)lblBackground).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnVoting;
        private Label Title;
        private Label lblVoted;
        private Label lblTitle;
        private PictureBox lblBackground;
        private Panel panel1;
    }
}
