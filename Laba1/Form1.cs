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

            maskSizeBox.Text = "1";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Filter = "Image files(*.jpeg;*.jpg;*.bmp;*.png)| *.jpeg;*.jpg;*.bmp;*.png";


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int maskSize = 0;
                try
                {
                    maskSize = Convert.ToInt32(maskSizeBox.Text);
                }
                catch ( Exception ex)
                {
                    MessageBox.Show("Размер маски должно быть положителное число", "Ошибка", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Bitmap image = Functions.openImage(openFileDialog1.FileName);
                execute(image, maskSize);

         
            }
        }

        private void execute(Bitmap originalImage, int sizeMask)
        {

            new Image(originalImage, Functions.getHistRGB(originalImage), "Оригинадльное изображжение").Show();

            // show grayScale images
            Bitmap graeyImage = Functions.Grayscale(originalImage);
            new Image(graeyImage, Functions.getHistGrayScale(graeyImage), "GrayScale изображение").Show();

            //show Negativ RGB image
            Bitmap negImage = Functions.Negativ(originalImage);
            new Image(negImage, Functions.getHistRGB(negImage), "Изображение в негативе").Show();

            //show Negativ greyscale image
            Bitmap negGraeyImage = Functions.Negativ(graeyImage);
            new Image(negGraeyImage, Functions.getHistGrayScale(negGraeyImage), "GrayScale изображение в негативе").Show();

            //show image with noise
            Bitmap noiseImage = Functions.noise(originalImage);
            new Image(noiseImage,"Зашумленное изображение").Show();

            //show greyscale image with noise
            Bitmap noiseGreyImage = Functions.Grayscale(noiseImage);
            new Image(noiseGreyImage, "Зашумленное grayScale изображение").Show();

            //show media-Filter RGB image
            Bitmap medianImage = Functions.median(noiseImage, sizeMask);
            new Image(medianImage, Functions.getHistRGB(medianImage),
                "Зашумленное изображение после медианного фильтра").Show();

            //show media-Filter RGB greyscale image
            Bitmap medianGraeyImage = Functions.median(noiseGreyImage, sizeMask);
            new Image(medianGraeyImage, Functions.getHistGrayScale(medianGraeyImage),
                "Зашумленное grayScale изображение после медианного фильтра").Show();

            //show ??? RGB image
            Bitmap avgImage = Functions.avarage(originalImage);
            new Image(avgImage, Functions.getHistRGB(avgImage), "?????").Show();

            //show ??? greyscale image
            Bitmap avgGraeyImage = Functions.avarage(graeyImage);
            new Image(avgGraeyImage, Functions.getHistGrayScale(avgGraeyImage), "?????").Show();


        }
    }
}
