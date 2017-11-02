namespace Laba4
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
            this.label1 = new System.Windows.Forms.Label();
            this.textNumberNeurons = new System.Windows.Forms.TextBox();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.trackBarText = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Learn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textSpeed = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBound = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textEpohNumbet = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Кол-во нейронов";
            // 
            // textNumberNeurons
            // 
            this.textNumberNeurons.Location = new System.Drawing.Point(111, 13);
            this.textNumberNeurons.Name = "textNumberNeurons";
            this.textNumberNeurons.Size = new System.Drawing.Size(81, 20);
            this.textNumberNeurons.TabIndex = 1;
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(9, 26);
            this.trackBar.Maximum = 20;
            this.trackBar.Minimum = 1;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(176, 45);
            this.trackBar.TabIndex = 2;
            this.trackBar.Value = 1;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // trackBarText
            // 
            this.trackBarText.AutoSize = true;
            this.trackBarText.Location = new System.Drawing.Point(84, 56);
            this.trackBarText.Name = "trackBarText";
            this.trackBarText.Size = new System.Drawing.Size(13, 13);
            this.trackBarText.TabIndex = 3;
            this.trackBarText.Text = "5";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Уровень шума в изображениях";
            // 
            // Learn
            // 
            this.Learn.Location = new System.Drawing.Point(14, 117);
            this.Learn.Name = "Learn";
            this.Learn.Size = new System.Drawing.Size(109, 23);
            this.Learn.TabIndex = 6;
            this.Learn.Text = "Обучить";
            this.Learn.UseVisualStyleBackColor = true;
            this.Learn.Click += new System.EventHandler(this.Learn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Кластеризовать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textSpeed);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBound);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textEpohNumbet);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textNumberNeurons);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Learn);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(562, 148);
            this.panel1.TabIndex = 7;
            // 
            // textSpeed
            // 
            this.textSpeed.Location = new System.Drawing.Point(111, 91);
            this.textSpeed.Name = "textSpeed";
            this.textSpeed.Size = new System.Drawing.Size(81, 20);
            this.textSpeed.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Скорость обучения";
            // 
            // textBound
            // 
            this.textBound.Location = new System.Drawing.Point(111, 65);
            this.textBound.Name = "textBound";
            this.textBound.Size = new System.Drawing.Size(81, 20);
            this.textBound.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Порог";
            // 
            // textEpohNumbet
            // 
            this.textEpohNumbet.Location = new System.Drawing.Point(111, 39);
            this.textEpohNumbet.Name = "textEpohNumbet";
            this.textEpohNumbet.Size = new System.Drawing.Size(81, 20);
            this.textEpohNumbet.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Кол-во эпох";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.trackBarText);
            this.panel2.Controls.Add(this.trackBar);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(1, 146);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(562, 121);
            this.panel2.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 263);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textNumberNeurons;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Label trackBarText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Learn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBound;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textEpohNumbet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textSpeed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
    }
}

