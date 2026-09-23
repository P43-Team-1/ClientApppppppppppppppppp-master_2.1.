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
            flowLayoutPanel1 = new FlowLayoutPanel();
            label1 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnVote = new Button();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Location = new Point(16, 32);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(398, 333);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 9);
            label1.MaximumSize = new Size(299, 0);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 1;
            label1.Text = "label1";
            label1.TextAlign = ContentAlignment.TopCenter;
            label1.SizeChanged += label1_SizeChanged;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Location = new Point(0, 569);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 83F));
            tableLayoutPanel1.Size = new Size(488, 83);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // btnVote
            // 
            btnVote.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnVote.Location = new Point(269, 409);
            btnVote.Margin = new Padding(3, 4, 3, 4);
            btnVote.Name = "btnVote";
            btnVote.Size = new Size(145, 40);
            btnVote.TabIndex = 4;
            btnVote.Text = "Проголосувати";
            btnVote.UseVisualStyleBackColor = true;
            btnVote.Click += btnVote_Click;
            // 
            // Voting
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(427, 465);
            Controls.Add(btnVote);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(label1);
            Controls.Add(flowLayoutPanel1);
            Name = "Voting";
            Text = " ";
            Load += Voting_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnVote;
    }
}