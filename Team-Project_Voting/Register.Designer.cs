namespace Team_Project_Voting
{
    partial class Register
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 36);
            label1.Name = "label1";
            label1.Size = new Size(35, 20);
            label1.TabIndex = 0;
            label1.Text = "Ім'я";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 137);
            label2.Name = "label2";
            label2.Size = new Size(47, 20);
            label2.TabIndex = 1;
            label2.Text = "Логін";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 245);
            label3.Name = "label3";
            label3.Size = new Size(62, 20);
            label3.TabIndex = 2;
            label3.Text = "Пароль";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(30, 59);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(244, 27);
            textBox1.TabIndex = 3;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(30, 160);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(244, 27);
            textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(30, 268);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(244, 27);
            textBox3.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(75, 335);
            button1.Name = "button1";
            button1.Size = new Size(135, 38);
            button1.TabIndex = 6;
            button1.Text = "Реєстрація";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(301, 402);
            Controls.Add(button1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Register";
            Text = "Register";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button button1;
    }
}