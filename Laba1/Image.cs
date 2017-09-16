using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba1
{
    public partial class Image : Form
    {
        const int offset = 10;
        const int histWidth = 400;
        const int histHight = 300;
        int[] masX = Enumerable.Range(1, 256).ToArray();
        public Image(Bitmap image, int[] masY) // 0 - black/white   1 - RGB
        {
            InitializeComponent();

            this.Width = 4 * offset + image.Width + histWidth;
            this.Height = 3 * offset + image.Height > histWidth ? image.Height : histWidth;

            PictureBox pBox = new PictureBox();
            pBox.SetBounds(offset, offset, image.Width, image.Height);
            pBox.Image = image;
            this.Controls.Add(pBox);

            var hist = new Chart();
            hist.Series.Add("Serias1");

            var chartArea = new ChartArea();
            chartArea.Name = "Area1";
            hist.ChartAreas.Add(chartArea);
            hist.Location = new Point(image.Width + 2 * offset, offset);
            hist.Size = new Size(histWidth, histHight);
            hist.Series["Serias1"].Points.DataBindXY(masX, masY);
            this.Controls.Add(hist);

        }

        public Image(Bitmap image, int[][] masY)
        {

            InitializeComponent();

            this.Width = 5 * offset + image.Width + 2 * histWidth;
            this.Height = 3 * offset + image.Height > 2 * histWidth ? image.Height : 2 * histWidth;

            PictureBox pBox = new PictureBox();
            pBox.SetBounds(offset, offset, image.Width, image.Height);
            pBox.Image = image;
            this.Controls.Add(pBox);

            var hist = new Chart[3];

            var chartArea = new ChartArea();
            chartArea.Name = "Area1";

            hist[0] = new Chart();
            hist[0].Series.Add("Serias1");
            hist[0].ChartAreas.Add(chartArea);
            hist[0].Location = new Point(image.Width + 2 * offset, offset);
            hist[0].Size = new Size(histWidth, histHight);
            hist[0].Series["Serias1"].Points.DataBindXY(masX, masY[0]);
            this.Controls.Add(hist[0]);

            var chartArea1 = new ChartArea();
            chartArea1.Name = "Area1";
            hist[1] = new Chart();
            hist[1].Series.Add("Serias1");
            hist[1].ChartAreas.Add(chartArea1);
            hist[1].Location = new Point(image.Width + 3 * offset + histWidth, offset);
            hist[1].Size = new Size(histWidth, histHight);
            hist[1].Series["Serias1"].Points.DataBindXY(masX, masY[1]);
            this.Controls.Add(hist[1]);

            var chartArea2 = new ChartArea();
            chartArea2.Name = "Area1";
            hist[2] = new Chart();
            hist[2].Series.Add("Serias1");
            hist[2].ChartAreas.Add(chartArea2);
            hist[2].Location = new Point(image.Width + 2 * offset, 2 * offset + histHight);
            hist[2].Size = new Size(histWidth, histHight);
            hist[2].Series["Serias1"].Points.DataBindXY(masX, masY[2]);
            this.Controls.Add(hist[2]);
        }
    }
}
