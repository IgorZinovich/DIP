using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba5
{
    public partial class Form1 : Form
    {
        readonly int N = 5;

        MultilayerPerceptron net;
        WorkImage work;
        Panel panelOriginal;
        Panel[] panel;

        PictureBox[] box;
        TextBox[][] lbl;



        readonly Size SIZE_PANEL = new Size(395, 70);
        readonly int PANEL_Y = 0;
        readonly int PANEL_X = 240;

        readonly Size SIZE_IMAGE = new Size(60, 60);
        readonly int IMAGE_Y = 5;
        readonly int IMAGE_X = 5;
        readonly int IMAGE_OFFSET = 5;

        readonly Size SIZE_LABEL = new Size(60, 10);
        readonly int LABEL_Y = 25;
        readonly int LABEL_X = 70;


        public Form1()
        {
            
            InitializeComponent();
            panel = new Panel[N];
            box = new PictureBox[N];
            lbl = new TextBox[N][];

            panelOriginal = new Panel();
            panelOriginal.Location = new Point(PANEL_X, PANEL_Y);
            panelOriginal.Size = SIZE_PANEL;
            Controls.Add(panelOriginal);

            for (int i = 0; i < panel.Length; i++)
            {

                panel[i] = new Panel();
                panel[i].Location = new Point(PANEL_X, PANEL_Y + SIZE_PANEL.Height * (i + 1));
                panel[i].Size = SIZE_PANEL;

                box[i] = new PictureBox();
                box[i].Location = new Point(IMAGE_X, IMAGE_Y);
                box[i].Size = SIZE_IMAGE;
                box[i].BackColor = Color.White;

                lbl[i] = new TextBox[N];
                for (int j = 0; j < N; j++)
                {
                    lbl[i][j] = new TextBox();
                    lbl[i][j].ReadOnly = true;
                    lbl[i][j].BackColor = Color.White;
                    lbl[i][j].Size = SIZE_LABEL;
                    lbl[i][j].Location = new Point(LABEL_X + (IMAGE_OFFSET + SIZE_LABEL.Width) * j, LABEL_Y);
                    panel[i].Controls.Add(lbl[i][j]);
                }
                panel[i].Controls.Add(box[i]);
                this.Controls.Add(panel[i]);
            }

          


           
            /*Random rand = new Random();
            for(int i =0; i < 1000000; i++)
            {
                Console.WriteLine(rand.Next(0, 1) == 0 ? rand.NextDouble() : -rand.NextDouble());
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            work.SetNoise(trackBar1.Value * 5);
            for (int i = 0; i < box.Length; i++)
            {
                double[] res = net.getCluster(work.vectorsNoise[i]);
                for (int j = 0; j < res.Length; j++)
                {
                    lbl[i][j].Text = (res[j] * 100.0).ToString("#0.00000") + "%";
                }

                box[i].Image = WorkImage.Zoom(work.noiseList[i], 10);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double alfa, beta, accur;
            try
            {
                alfa = Convert.ToDouble(alfaText.Text.Replace(".", ","));
                beta = Convert.ToDouble(betaText.Text.Replace(".", ","));
                accur = Convert.ToDouble(accurText.Text.Replace(".", ","));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Введены не верные значения!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Cursor = Cursors.WaitCursor;
            net = null;
            net = new MultilayerPerceptron(alfa, beta, accur);
            net.learn(work.vectors, work.cluster);
            if(net.accur)
            {
                label6.Text = "Точность достигнута";
            }
            else
            {
                label6.Text = "Точность не достигнута";
            }
            button1.Enabled = true;
            Cursor = Cursors.Arrow;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label4.Text = (trackBar1.Value * 5).ToString() + "%";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop; //= Directory.GetCurrentDirectory();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                work = new WorkImage(folderBrowserDialog1.SelectedPath);
                textBox1.Text = folderBrowserDialog1.SelectedPath;
                for (int i = 0; i < work.list.Count; i++)
                {
                    PictureBox box = new PictureBox();
                    box.Size = SIZE_IMAGE;
                    box.Location = new Point(IMAGE_X + (IMAGE_OFFSET + SIZE_IMAGE.Width) * (i + 1), IMAGE_Y);
                    box.Image = WorkImage.Zoom(work.list[i], 10);
                    panelOriginal.Controls.Add(box);
                }
                button2.Enabled = true;
            }
            
        }
    }
}
