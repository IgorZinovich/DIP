using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {


                Bitmap imageOriginal = Functions.openImage(openFileDialog1.FileName);
                Int32[][] masRGB = { Functions.getHist(imageOriginal, 0), Functions.getHist(imageOriginal, 1), 
                                       Functions.getHist(imageOriginal, 2) };

                //Functions.median(imageOriginal, 1);
                // Bitmap imageGrey = Functions.Grayscale(imageOriginal);
                /* Int32[] masY = Functions.getHist(imageGrey, 0);

                 Bitmap imageOriginalN = Functions.Negativ(imageOriginal);
                 Int32[][] masRGBN = { Functions.getHist(imageOriginalN, 0), Functions.getHist(imageOriginalN, 1), 
                                        Functions.getHist(imageOriginalN, 2) */

               /*  Bitmap imageGreyN = Functions.Negativ(imageGrey);
                 Int32[] masYN = Functions.getHist(imageGreyN, 0);*/

                //imageOriginal = Functions.noise(imageOriginal);
                //imageOriginal = Functions.median(imageOriginal, 1);
              /*  imageOriginal = Functions.avarage(imageOriginal);
                Image windowOriginal = new Image(imageOriginal, masRGB);
                windowOriginal.Show();

                 Image windowGray = new Image(imageGrey, masY);
                 windowGray.Show();*/

                 /*Image windowOriginalN = new Image(imageOriginalN, masRGBN);
                 windowOriginalN.Show();
                 Image windowGrayN = new Image(imageGreyN, masYN);
                 windowGrayN.Show();*/
            }
        }


    }
}
