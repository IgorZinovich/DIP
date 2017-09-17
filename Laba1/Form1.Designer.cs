namespace Laba1
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.maskSizeBox = new System.Windows.Forms.TextBox();
            this.checkBoxIm = new System.Windows.Forms.CheckBox();
            this.checkBoxImG = new System.Windows.Forms.CheckBox();
            this.checkBoxNegativ = new System.Windows.Forms.CheckBox();
            this.checkBoxNegativG = new System.Windows.Forms.CheckBox();
            this.checkBoxNoise = new System.Windows.Forms.CheckBox();
            this.checkBoxNoiseG = new System.Windows.Forms.CheckBox();
            this.checkBoxMedium = new System.Windows.Forms.CheckBox();
            this.checkBoxAVG = new System.Windows.Forms.CheckBox();
            this.checkBoxMediumG = new System.Windows.Forms.CheckBox();
            this.checkBoxAVGG = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxRGB = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxG = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(381, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Выбрать файл";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Размер маски медианного фильтра";
            // 
            // maskSizeBox
            // 
            this.maskSizeBox.Location = new System.Drawing.Point(207, 52);
            this.maskSizeBox.Name = "maskSizeBox";
            this.maskSizeBox.Size = new System.Drawing.Size(63, 20);
            this.maskSizeBox.TabIndex = 2;
            // 
            // checkBoxIm
            // 
            this.checkBoxIm.AutoSize = true;
            this.checkBoxIm.Location = new System.Drawing.Point(6, 42);
            this.checkBoxIm.Name = "checkBoxIm";
            this.checkBoxIm.Size = new System.Drawing.Size(96, 17);
            this.checkBoxIm.TabIndex = 3;
            this.checkBoxIm.Text = "Изображение";
            this.checkBoxIm.UseVisualStyleBackColor = true;
            this.checkBoxIm.CheckedChanged += new System.EventHandler(this.checkBoxRGB_CheckChanged);
            // 
            // checkBoxImG
            // 
            this.checkBoxImG.AutoSize = true;
            this.checkBoxImG.Location = new System.Drawing.Point(6, 42);
            this.checkBoxImG.Name = "checkBoxImG";
            this.checkBoxImG.Size = new System.Drawing.Size(96, 17);
            this.checkBoxImG.TabIndex = 3;
            this.checkBoxImG.Text = "Изображение";
            this.checkBoxImG.UseVisualStyleBackColor = true;
            this.checkBoxImG.CheckedChanged += new System.EventHandler(this.checkBoxG_CheckChanged);
            // 
            // checkBoxNegativ
            // 
            this.checkBoxNegativ.AutoSize = true;
            this.checkBoxNegativ.Location = new System.Drawing.Point(6, 65);
            this.checkBoxNegativ.Name = "checkBoxNegativ";
            this.checkBoxNegativ.Size = new System.Drawing.Size(68, 17);
            this.checkBoxNegativ.TabIndex = 3;
            this.checkBoxNegativ.Text = "Негатив";
            this.checkBoxNegativ.UseVisualStyleBackColor = true;
            this.checkBoxNegativ.CheckedChanged += new System.EventHandler(this.checkBoxRGB_CheckChanged);
            // 
            // checkBoxNegativG
            // 
            this.checkBoxNegativG.AutoSize = true;
            this.checkBoxNegativG.Location = new System.Drawing.Point(6, 65);
            this.checkBoxNegativG.Name = "checkBoxNegativG";
            this.checkBoxNegativG.Size = new System.Drawing.Size(68, 17);
            this.checkBoxNegativG.TabIndex = 3;
            this.checkBoxNegativG.Text = "Негатив";
            this.checkBoxNegativG.UseVisualStyleBackColor = true;
            this.checkBoxNegativG.CheckedChanged += new System.EventHandler(this.checkBoxG_CheckChanged);
            // 
            // checkBoxNoise
            // 
            this.checkBoxNoise.AutoSize = true;
            this.checkBoxNoise.Location = new System.Drawing.Point(6, 88);
            this.checkBoxNoise.Name = "checkBoxNoise";
            this.checkBoxNoise.Size = new System.Drawing.Size(167, 17);
            this.checkBoxNoise.TabIndex = 3;
            this.checkBoxNoise.Text = "Зашумленное изображение";
            this.checkBoxNoise.UseVisualStyleBackColor = true;
            this.checkBoxNoise.CheckedChanged += new System.EventHandler(this.checkBoxRGB_CheckChanged);
            // 
            // checkBoxNoiseG
            // 
            this.checkBoxNoiseG.AutoSize = true;
            this.checkBoxNoiseG.Location = new System.Drawing.Point(6, 88);
            this.checkBoxNoiseG.Name = "checkBoxNoiseG";
            this.checkBoxNoiseG.Size = new System.Drawing.Size(167, 17);
            this.checkBoxNoiseG.TabIndex = 3;
            this.checkBoxNoiseG.Text = "Зашумленное изображение";
            this.checkBoxNoiseG.UseVisualStyleBackColor = true;
            this.checkBoxNoiseG.CheckedChanged += new System.EventHandler(this.checkBoxG_CheckChanged);
            // 
            // checkBoxMedium
            // 
            this.checkBoxMedium.AutoSize = true;
            this.checkBoxMedium.Location = new System.Drawing.Point(6, 111);
            this.checkBoxMedium.Name = "checkBoxMedium";
            this.checkBoxMedium.Size = new System.Drawing.Size(125, 17);
            this.checkBoxMedium.TabIndex = 3;
            this.checkBoxMedium.Text = "Мединнный фильтр";
            this.checkBoxMedium.UseVisualStyleBackColor = true;
            this.checkBoxMedium.CheckedChanged += new System.EventHandler(this.checkBoxRGB_CheckChanged);
            // 
            // checkBoxAVG
            // 
            this.checkBoxAVG.AutoSize = true;
            this.checkBoxAVG.Location = new System.Drawing.Point(6, 134);
            this.checkBoxAVG.Name = "checkBoxAVG";
            this.checkBoxAVG.Size = new System.Drawing.Size(204, 17);
            this.checkBoxAVG.TabIndex = 3;
            this.checkBoxAVG.Text = "Фильтр «гармоническое среднее»";
            this.checkBoxAVG.UseVisualStyleBackColor = true;
            this.checkBoxAVG.CheckedChanged += new System.EventHandler(this.checkBoxRGB_CheckChanged);
            // 
            // checkBoxMediumG
            // 
            this.checkBoxMediumG.AutoSize = true;
            this.checkBoxMediumG.Location = new System.Drawing.Point(6, 111);
            this.checkBoxMediumG.Name = "checkBoxMediumG";
            this.checkBoxMediumG.Size = new System.Drawing.Size(125, 17);
            this.checkBoxMediumG.TabIndex = 3;
            this.checkBoxMediumG.Text = "Мединнный фильтр";
            this.checkBoxMediumG.UseVisualStyleBackColor = true;
            this.checkBoxMediumG.CheckedChanged += new System.EventHandler(this.checkBoxG_CheckChanged);
            // 
            // checkBoxAVGG
            // 
            this.checkBoxAVGG.AutoSize = true;
            this.checkBoxAVGG.Location = new System.Drawing.Point(6, 134);
            this.checkBoxAVGG.Name = "checkBoxAVGG";
            this.checkBoxAVGG.Size = new System.Drawing.Size(204, 17);
            this.checkBoxAVGG.TabIndex = 3;
            this.checkBoxAVGG.Text = "Фильтр «гармоническое среднее»";
            this.checkBoxAVGG.UseVisualStyleBackColor = true;
            this.checkBoxAVGG.CheckedChanged += new System.EventHandler(this.checkBoxG_CheckChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxRGB);
            this.groupBox1.Controls.Add(this.checkBoxIm);
            this.groupBox1.Controls.Add(this.checkBoxNegativ);
            this.groupBox1.Controls.Add(this.checkBoxAVG);
            this.groupBox1.Controls.Add(this.checkBoxNoise);
            this.groupBox1.Controls.Add(this.checkBoxMedium);
            this.groupBox1.Location = new System.Drawing.Point(12, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 159);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RGB";
            // 
            // checkBoxRGB
            // 
            this.checkBoxRGB.AutoSize = true;
            this.checkBoxRGB.Location = new System.Drawing.Point(6, 19);
            this.checkBoxRGB.Name = "checkBoxRGB";
            this.checkBoxRGB.Size = new System.Drawing.Size(71, 17);
            this.checkBoxRGB.TabIndex = 8;
            this.checkBoxRGB.Text = "Все RGB";
            this.checkBoxRGB.UseVisualStyleBackColor = true;
            this.checkBoxRGB.CheckStateChanged += new System.EventHandler(this.checkBoxRGB_G_CheckStateChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxG);
            this.groupBox2.Controls.Add(this.checkBoxImG);
            this.groupBox2.Controls.Add(this.checkBoxNegativG);
            this.groupBox2.Controls.Add(this.checkBoxAVGG);
            this.groupBox2.Controls.Add(this.checkBoxNoiseG);
            this.groupBox2.Controls.Add(this.checkBoxMediumG);
            this.groupBox2.Location = new System.Drawing.Point(331, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(220, 159);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "GreyScale";
            // 
            // checkBoxG
            // 
            this.checkBoxG.AutoSize = true;
            this.checkBoxG.Location = new System.Drawing.Point(6, 19);
            this.checkBoxG.Name = "checkBoxG";
            this.checkBoxG.Size = new System.Drawing.Size(97, 17);
            this.checkBoxG.TabIndex = 8;
            this.checkBoxG.Text = "Все GrayScale";
            this.checkBoxG.UseVisualStyleBackColor = true;
            this.checkBoxG.CheckStateChanged += new System.EventHandler(this.checkBoxRGB_G_CheckStateChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Выбранный файл";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(113, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(262, 20);
            this.textBox1.TabIndex = 7;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(13, 77);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(91, 17);
            this.checkBox3.TabIndex = 8;
            this.checkBox3.Text = "Выбрать все";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(381, 55);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(180, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Показать рузльтат";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 261);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.maskSizeBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox maskSizeBox;
        private System.Windows.Forms.CheckBox checkBoxIm;
        private System.Windows.Forms.CheckBox checkBoxImG;
        private System.Windows.Forms.CheckBox checkBoxNegativ;
        private System.Windows.Forms.CheckBox checkBoxNegativG;
        private System.Windows.Forms.CheckBox checkBoxNoise;
        private System.Windows.Forms.CheckBox checkBoxNoiseG;
        private System.Windows.Forms.CheckBox checkBoxMedium;
        private System.Windows.Forms.CheckBox checkBoxAVG;
        private System.Windows.Forms.CheckBox checkBoxMediumG;
        private System.Windows.Forms.CheckBox checkBoxAVGG;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBoxRGB;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBoxG;
        private System.Windows.Forms.Button button2;
    }
}

