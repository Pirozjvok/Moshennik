namespace Moshennik
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
            panel1 = new DoubleBufferedPanel();
            panel2 = new DoubleBufferedPanel();
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            trackBar1 = new TrackBar();
            trackBar2 = new TrackBar();
            checkBox1 = new CheckBox();
            pictureBox1 = new PictureBox();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(519, 624);
            panel1.TabIndex = 0;
            panel1.Paint += Panel1_Paint;
            panel1.MouseDown += panel1_MouseDown;
            panel1.MouseMove += panel1_MouseMove;
            panel1.MouseUp += panel1_MouseUp;
            // 
            // panel2
            // 
            panel2.Location = new Point(847, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(550, 624);
            panel2.TabIndex = 1;
            panel2.Paint += Panel2_Paint;
            panel2.MouseDown += panel2_MouseDown;
            panel2.MouseMove += panel2_MouseMove;
            // 
            // button1
            // 
            button1.Location = new Point(537, 12);
            button1.Name = "button1";
            button1.Size = new Size(304, 23);
            button1.TabIndex = 2;
            button1.Text = "Загрузить документ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(537, 41);
            button2.Name = "button2";
            button2.Size = new Size(304, 23);
            button2.TabIndex = 3;
            button2.Text = "Загрузить документ обманку";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(537, 75);
            label1.Name = "label1";
            label1.Size = new Size(70, 15);
            label1.TabIndex = 5;
            label1.Text = "Hue Center:";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(658, 70);
            numericUpDown1.Maximum = new decimal(new int[] { 360, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(183, 23);
            numericUpDown1.TabIndex = 6;
            numericUpDown1.Value = new decimal(new int[] { 225, 0, 0, 0 });
            numericUpDown1.ValueChanged += Value_Changed;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(658, 99);
            numericUpDown2.Maximum = new decimal(new int[] { 360, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(183, 23);
            numericUpDown2.TabIndex = 8;
            numericUpDown2.Value = new decimal(new int[] { 50, 0, 0, 0 });
            numericUpDown2.ValueChanged += Value_Changed;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(537, 103);
            label2.Name = "label2";
            label2.Size = new Size(87, 15);
            label2.TabIndex = 7;
            label2.Text = "Hue Threshold:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(536, 134);
            label3.Name = "label3";
            label3.Size = new Size(119, 15);
            label3.TabIndex = 9;
            label3.Text = "Saturation Threshold:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(536, 170);
            label4.Name = "label4";
            label4.Size = new Size(120, 15);
            label4.TabIndex = 10;
            label4.Text = "Brightness Threshold:";
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(658, 128);
            trackBar1.Maximum = 100;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(183, 45);
            trackBar1.TabIndex = 11;
            trackBar1.Value = 20;
            trackBar1.ValueChanged += Value_Changed;
            // 
            // trackBar2
            // 
            trackBar2.Location = new Point(658, 167);
            trackBar2.Maximum = 100;
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(183, 45);
            trackBar2.TabIndex = 12;
            trackBar2.Value = 60;
            trackBar2.ValueChanged += Value_Changed;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(537, 203);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(51, 19);
            checkBox1.TabIndex = 13;
            checkBox1.Text = "View";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(536, 228);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(305, 225);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            // 
            // button3
            // 
            button3.Location = new Point(536, 459);
            button3.Name = "button3";
            button3.Size = new Size(305, 23);
            button3.TabIndex = 15;
            button3.Text = "Вставить картинку в обманку";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(536, 488);
            button4.Name = "button4";
            button4.Size = new Size(305, 23);
            button4.TabIndex = 16;
            button4.Text = "Установить";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(536, 517);
            button5.Name = "button5";
            button5.Size = new Size(305, 23);
            button5.TabIndex = 17;
            button5.Text = "Сохранить";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1409, 648);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(pictureBox1);
            Controls.Add(checkBox1);
            Controls.Add(trackBar2);
            Controls.Add(trackBar1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(numericUpDown2);
            Controls.Add(label2);
            Controls.Add(numericUpDown1);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Мошенник";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private DoubleBufferedPanel panel1;
        private DoubleBufferedPanel panel2;
        private Button button1;
        private Button button2;
        private Label label1;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private Label label2;
        private Label label3;
        private Label label4;
        private TrackBar trackBar1;
        private TrackBar trackBar2;
        private CheckBox checkBox1;
        private PictureBox pictureBox1;
        private Button button3;
        private Button button4;
        private Button button5;
    }
}