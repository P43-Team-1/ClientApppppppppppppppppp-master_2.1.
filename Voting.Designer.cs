namespace Team_Project_Voting
{
    partial class Voting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Statistic = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label1 = new Label();
            SuspendLayout();
            // 
            // Statistic
            // 
            Statistic.AutoSize = true;
            Statistic.Cursor = Cursors.Hand;
            Statistic.Location = new Point(1, 377);
            Statistic.Name = "Statistic";
            Statistic.Size = new Size(174, 20);
            Statistic.TabIndex = 1;
            Statistic.Text = "Переглянути статистику";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(16, 88);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(391, 277);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 9);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 3;
            label1.Text = "label1";
            // 
            // Voting
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(426, 406);
            Controls.Add(label1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(Statistic);
            Name = "Voting";
            Text = "Voting";
            Load += Voting_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label Statistic;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
    }
}