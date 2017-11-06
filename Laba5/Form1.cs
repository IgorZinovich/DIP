using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba5
{
    public partial class Form1 : Form
    {
        MultilayerPerceptron net;
        WorkImage work;
        Panel[] panel = new Panel[5];
        Panel panelOriginal;

        readonly Size SIZE_PANEL = new Size(395, 80);
        readonly int PANEL_Y = 0;
        readonly int PANEL_X = 240;

        readonly Size SIZE_IMAGE = new Size(60, 60);
        readonly int IMAGE_Y = 0;
        readonly int IMAGE_X = 5;
        readonly int IMAGE_OFFSET = 5;


        public Form1()
        {
            work = new WorkImage();
            InitializeComponent();

            panelOriginal = new Panel();
            panelOriginal.Location = new Point(PANEL_X, PANEL_Y);
            panelOriginal.Size = SIZE_PANEL;
            Controls.Add(panelOriginal);

            for(int i = 0; i < panel.Length; i++)
            {
                panel[i] = new Panel();
                panel[i].Location = new Point(PANEL_X, PANEL_Y + SIZE_PANEL.Height * (i+1));
                panel[i].Size = SIZE_PANEL;
                this.Controls.Add(panel[i]);
            }

            for(int i = 0; i< work.list.Count; i++)
            {
                PictureBox box = new PictureBox();
                box.Size = SIZE_IMAGE;
                box.Location = new Point(IMAGE_X + (IMAGE_OFFSET + SIZE_IMAGE.Width) * (i+1), IMAGE_Y + 10);
                box.Image = WorkImage.Zoom(work.list[i], 10);
                panelOriginal.Controls.Add(box);
            }

            /*
            net = new MultilayerPerceptron();
            net.learn(work.vectors, work.cluster);
            double[] c = net.getCluster(work.vectors[0]);
            double[] c1 = net.getCluster(work.vectors[1]);
            double[] c2 = net.getCluster(work.vectors[2]);
            double[] c3 = net.getCluster(work.vectors[3]);
            double[] c4 = net.getCluster(work.vectors[4]);*/
            /*Random rand = new Random();
            for(int i =0; i < 1000000; i++)
            {
                Console.WriteLine(rand.Next(0, 1) == 0 ? rand.NextDouble() : -rand.NextDouble());
            }*/
        }
    }
}
