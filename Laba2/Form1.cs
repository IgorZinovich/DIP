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
            Bitmap im = Functions.openImage(@"C:\Users\diego\Desktop\easy\P0001460.jpg");
            PictureBox box = new PictureBox();
            box.SetBounds(0, 0, im.Width, im.Height + 50);
            this.Size = new Size(im.Width, im.Height);
            
            Bitmap temp = Functions.Binarization(Functions.median(Functions.median(im, 2), 1), 230);
            List<byte[][]> all = Functions.GetFigure(temp);
            Functions.Perimetr(all[0]);
            box.Image = temp;
            
            this.Controls.Add(box);
        }
       /* public void printf(byte[][] im)
        {
            StreamWriter sw = new StreamWriter(@"D:\444.txt");
            for (int i = 0; i < im.Length; i++ )
            {
                for (int j = 0; j < im[i].Length; j++ )
                {
                    sw.Write(im[i][j].ToString());
                }
                sw.WriteLine();
            }
            sw.Close();
            
            
        }*/
    }
}
