using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba4
{
    public partial class Form1 : Form
    {
        private CompetitevNetwork net;
        private WorkImage work = new WorkImage();
        private PictureBox[] pBox = new PictureBox[5];
        private PictureBox[] pBoxNoise = new PictureBox[5];
        private Label[] textCluster = new Label[5];
        private Label[] textClusterNoise = new Label[5];
        readonly int START_X = 220;
        readonly int START_Y = 15;
        readonly int OFFSET = 5;
        readonly Size SIZE_BOX = new Size(60, 60);
        readonly Size SIZE_TEXT = new Size(60, 15);
        public Form1()
        {

            InitializeComponent();
            for (int i = 0; i < pBox.Length; i++)
            {
                pBox[i] = new PictureBox();
                pBox[i].Location = new System.Drawing.Point(START_X + i*OFFSET + i * SIZE_BOX.Width, START_Y);
                pBox[i].Name = "pictureBox";
                pBox[i].Size = SIZE_BOX;
                pBox[i].SizeMode = PictureBoxSizeMode.StretchImage;
                pBox[i].Image = WorkImage.Zoom(work.list[i], 10);
                this.panel1.Controls.Add(pBox[i]);

                pBoxNoise[i] = new PictureBox();
                pBoxNoise[i].Location = new System.Drawing.Point(START_X + i * OFFSET + i * SIZE_BOX.Width, START_Y);
                pBoxNoise[i].Name = "pictureBox";
                pBoxNoise[i].Size = SIZE_BOX;
                pBoxNoise[i].SizeMode = PictureBoxSizeMode.StretchImage;
                this.panel2.Controls.Add(pBoxNoise[i]);
            }
            for(int i = 0; i<textCluster.Length;i++)
            {
                textCluster[i] = new Label();
                textCluster[i].Location = new Point(START_X + i * OFFSET + i * SIZE_BOX.Width, START_Y + OFFSET + SIZE_BOX.Height);
                textCluster[i].Size = SIZE_TEXT;
                this.panel1.Controls.Add(textCluster[i]);
                textClusterNoise[i] = new Label();
                textClusterNoise[i].Location = new Point(START_X + i * OFFSET + i * SIZE_BOX.Width, START_Y + OFFSET + SIZE_BOX.Height);
                textClusterNoise[i].Size = SIZE_TEXT;
                this.panel2.Controls.Add(textClusterNoise[i]);
            }
            textNumberNeurons.Text = "3";
            textEpohNumbet.Text = "1000";
            textBound.Text = "0.0001";
            textSpeed.Text = "0.01";

        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {

            trackBarText.Text = (trackBar.Value * 5).ToString();
        }

        private void Learn_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            net = null;
            int M = Convert.ToInt32(this.textNumberNeurons.Text);
            int maxEpoh = Convert.ToInt32(this.textEpohNumbet.Text);
            double bound = Convert.ToDouble(this.textBound.Text.Replace('.', ','));
            double beta = Convert.ToDouble(this.textSpeed.Text.Replace('.', ','));


            net = new CompetitevNetwork(M,maxEpoh, bound, beta);
            net.learn(work.vectors);
            for (int i = 0; i < work.vectors.Count; i++)
            {
                 textCluster[i].Text =  net.getCluster(work.vectors[i]).ToString();
            }
            this.Cursor = Cursors.Arrow;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(net == null)
            {
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            work.SetNoise(trackBar.Value * 5);
            for(int i = 0; i < work.noiseList.Count; i++)
            {
                textClusterNoise[i].Text = net.getCluster(work.vectorsNoise[i]).ToString();
                pBoxNoise[i].Image = WorkImage.Zoom(work.noiseList[i], 10);
            }
            this.Cursor = Cursors.Arrow;
        }
    }
}
