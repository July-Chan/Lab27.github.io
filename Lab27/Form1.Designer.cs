namespace Lab27
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBox1 = new ListBox();
            button1 = new Button();
            button2 = new Button();
            listBox2 = new ListBox();
            button4 = new Button();
            button3 = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            listBox3 = new ListBox();
            button5 = new Button();
            button6 = new Button();
            listBox4 = new ListBox();
            listBox5 = new ListBox();
            button7 = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 33;
            listBox1.Location = new Point(13, 13);
            listBox1.Margin = new Padding(4);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(177, 202);
            listBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(223, 40);
            button1.Name = "button1";
            button1.Size = new Size(306, 54);
            button1.TabIndex = 2;
            button1.Text = "Властивості диску";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(223, 120);
            button2.Name = "button2";
            button2.Size = new Size(306, 54);
            button2.TabIndex = 2;
            button2.Text = "Перемістити файл";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 33;
            listBox2.Location = new Point(596, 13);
            listBox2.Margin = new Padding(4);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(516, 202);
            listBox2.TabIndex = 0;
            // 
            // button4
            // 
            button4.Location = new Point(1149, 37);
            button4.Name = "button4";
            button4.Size = new Size(517, 54);
            button4.TabIndex = 3;
            button4.Text = "Властивості каталогу/файлу";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(1149, 120);
            button3.Name = "button3";
            button3.Size = new Size(517, 54);
            button3.TabIndex = 3;
            button3.Text = "Отримати каталог";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 296);
            label1.Name = "label1";
            label1.Size = new Size(265, 33);
            label1.TabIndex = 4;
            label1.Text = "Фільтрування файлів";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(313, 296);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(513, 40);
            textBox1.TabIndex = 5;
            // 
            // listBox3
            // 
            listBox3.FormattingEnabled = true;
            listBox3.ItemHeight = 33;
            listBox3.Location = new Point(13, 361);
            listBox3.Margin = new Padding(4);
            listBox3.Name = "listBox3";
            listBox3.Size = new Size(813, 202);
            listBox3.TabIndex = 0;
            // 
            // button5
            // 
            button5.Location = new Point(13, 590);
            button5.Name = "button5";
            button5.Size = new Size(813, 54);
            button5.TabIndex = 6;
            button5.Text = "Фільтрувати";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(852, 590);
            button6.Name = "button6";
            button6.Size = new Size(814, 54);
            button6.TabIndex = 6;
            button6.Text = "Переглянути атрибути безпеки";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // listBox4
            // 
            listBox4.FormattingEnabled = true;
            listBox4.ItemHeight = 33;
            listBox4.Location = new Point(852, 361);
            listBox4.Margin = new Padding(4);
            listBox4.Name = "listBox4";
            listBox4.Size = new Size(813, 202);
            listBox4.TabIndex = 0;
            // 
            // listBox5
            // 
            listBox5.FormattingEnabled = true;
            listBox5.ItemHeight = 33;
            listBox5.Location = new Point(441, 673);
            listBox5.Margin = new Padding(4);
            listBox5.Name = "listBox5";
            listBox5.Size = new Size(813, 466);
            listBox5.TabIndex = 0;
            // 
            // button7
            // 
            button7.Location = new Point(440, 1167);
            button7.Name = "button7";
            button7.Size = new Size(814, 54);
            button7.TabIndex = 6;
            button7.Text = "Переглянути вміст текстового файла";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(15F, 33F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1678, 1250);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button4);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(listBox5);
            Controls.Add(listBox4);
            Controls.Add(listBox3);
            Controls.Add(listBox2);
            Controls.Add(listBox1);
            Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4);
            Name = "Form1";
            ShowIcon = false;
            Text = "Лабораторна 27 Кривонос";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private Button button1;
        private Button button2;
        private ListBox listBox2;
        private Button button4;
        private Button button3;
        private Label label1;
        private TextBox textBox1;
        private ListBox listBox3;
        private Button button5;
        private Button button6;
        private ListBox listBox4;
        private ListBox listBox5;
        private Button button7;
    }
}
