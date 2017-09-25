using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Laba2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Bitmap im = Functions.openImage(@"C:\Users\diego\Desktop\easy\P0001468.jpg");
            PictureBox box = new PictureBox();
            box.SetBounds(0, 0, im.Width, im.Height + 50);
            this.Size = new Size(im.Width, im.Height);
            Bitmap temp = Functions.Binarization(Functions.median(Functions.median(im, 2), 1), 225);
            List<Figure> all = Functions.GetFigure(temp);
            
            List<Figure>[] clust = Functions.Clustarization(all, 2);
            highlight(im, clust);
            box.Image = im;
            this.Controls.Add(box);
        }
        private void highlight(Bitmap image, List<Figure>[] clusters)
        {
            int i = 0;
            foreach(var clust in clusters)
            {
                foreach(var figure in clust)
                {
                    for(int x = figure.minX; x<=figure.maxX;x++)
                    {
                        for(int y = figure.minY; y<=figure.maxY;y++)
                        {
                            if (figure.map[x][y] == 1)
                            {
                                Color color = image.GetPixel(x, y);
                                switch (i)
                                {
                                    case 0: image.SetPixel(x, y, Color.FromArgb(Convert.ToInt32(color.R * 0.3),
                                        Convert.ToInt32(color.G), Convert.ToInt32(color.B * 0.3))); break;
                                    case 1: image.SetPixel(x, y, Color.FromArgb(Convert.ToInt32(color.R),
                                        Convert.ToInt32(color.G * 0.3), Convert.ToInt32(color.B * 0.3))); break;
                                    default: image.SetPixel(x, y, Color.FromArgb(Convert.ToInt32(color.R * 0.3),
                                        Convert.ToInt32(color.G * 0.3), Convert.ToInt32(color.B * 0.3))); break;
                                }
                            }
                        }
                    }
                }
                i++;
            }
        }
    }
}
