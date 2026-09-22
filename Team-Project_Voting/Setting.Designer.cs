namespace Team_Project_Voting
{
    partial class Setting
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            label1 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(621, 149);
            button1.Name = "button1";
            button1.Size = new Size(138, 46);
            button1.TabIndex = 4;
            button1.Text = "Скасувати голосування";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(621, 225);
            button2.Name = "button2";
            button2.Size = new Size(138, 48);
            button2.TabIndex = 5;
            button2.Text = "Очистити голосування";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(621, 56);
            button3.Name = "button3";
            button3.Size = new Size(138, 48);
            button3.TabIndex = 6;
            button3.Text = "Зберегти голосування";
            button3.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(44, 70);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(294, 23);
            textBox1.TabIndex = 7;
            textBox1.Text = "Назва голосування";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(44, 162);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(294, 138);
            textBox2.TabIndex = 8;
            textBox2.Text = "Варіанти відповіді(Кожна відповідь з нового рядка)";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = " dd MMMM yyyy р. HH:mm";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(44, 361);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(294, 23);
            dateTimePicker1.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 343);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 10;
            label1.Text = "Час закінчення";
            // 
            // Setting
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Setting";
            Text = "Setting";
            Load += Setting_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private Button button2;
        private Button button3;
        private TextBox textBox1;
        private TextBox textBox2;
        private DateTimePicker dateTimePicker1;
        private Label label1;
    }
}