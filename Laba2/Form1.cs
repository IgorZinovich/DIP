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
            
            Bitmap temp = Functions.Binarization(Functions.median(Functions.median(im, 2), 1), 230);
            List<Figure> all = Functions.GetFigure(temp);
            box.Image = temp;
            Functions.Clustarization(all, 2);
            this.Controls.Add(box);
        }

    }
}
