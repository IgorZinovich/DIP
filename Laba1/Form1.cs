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
        bool RGB = true;
        bool flag = true;
        bool Grey = true;
        Bitmap originalImage;
        Bitmap graeyImage;
        Bitmap negImage;
        Bitmap negGraeyImage;
        Bitmap noiseGreyImage;
        Bitmap noiseImage;
        Bitmap medianImage;
        Bitmap medianGraeyImage;
        Bitmap avgImage;
        Bitmap avgGraeyImage;

        Int32[][] originalHist;
        Int32[] graeyHist;
        Int32[][] negHist;
        Int32[] negGraeyHist;
        Int32[][] medianHist;
        Int32[] medianGraeyHist;
        Int32[][] avgHist;
        Int32[] avgGraeyHist;

        int maskSize = 1;
        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;
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

                try
                {
                    maskSize = Convert.ToInt32(maskSizeBox.Text);
                }               
                catch (Exception ex)
                {
                    MessageBox.Show("Размер маски должно быть положителное число", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                textBox1.Text = openFileDialog1.FileName;
                originalImage = Functions.openImage(openFileDialog1.FileName);
                graeyImage = Functions.Grayscale(originalImage);
                negImage = Functions.Negativ(originalImage);
                negGraeyImage = Functions.Negativ(graeyImage);
                noiseImage = Functions.noise(originalImage);
                noiseGreyImage = Functions.Grayscale(noiseImage);
                medianImage = Functions.median(noiseImage, maskSize);
                medianGraeyImage = Functions.median(noiseGreyImage, maskSize);
                avgImage = Functions.avarage(originalImage);
                avgGraeyImage = Functions.avarage(graeyImage);

                originalHist = Functions.getHistRGB(originalImage);
                graeyHist = Functions.getHistGrayScale(graeyImage);
                negHist = Functions.getHistRGB(negImage);
                negGraeyHist = Functions.getHistGrayScale(negGraeyImage);
                medianHist = Functions.getHistRGB(medianImage);
                medianGraeyHist = Functions.getHistGrayScale(medianGraeyImage);
                avgHist = Functions.getHistRGB(avgImage);
                avgGraeyHist = Functions.getHistGrayScale(avgGraeyImage);
                button2.Enabled = true;
                this.Cursor = System.Windows.Forms.Cursors.Arrow;
              
            }
        }

        private void execute()
        {
            if (checkBoxIm.Checked)
            {
                new Image(originalImage, originalHist, "Оригинадльное изображжение").Show();
            }
            // show grayScale images

            if (checkBoxImG.Checked)
            {
                new Image(graeyImage, graeyHist, "GrayScale изображение").Show();
            }

            //show Negativ RGB image
            if (checkBoxNegativ.Checked)
            {
                new Image(negImage, negHist, "Изображение в негативе").Show();
            }
            //show Negativ greyscale image
            if (checkBoxNegativG.Checked)
            {
                new Image(negGraeyImage, negGraeyHist, "GrayScale изображение в негативе").Show();
            }

            //show image with noise
            if (checkBoxNoise.Checked)
            {
                new Image(noiseImage, "Зашумленное изображение").Show();
            }

            //show greyscale image with noise
            if (checkBoxNoiseG.Checked)
            {
                new Image(noiseGreyImage, "Зашумленное grayScale изображение").Show();
            }
            //show media-Filter RGB image
            if (checkBoxMedium.Checked)
            {
                new Image(medianImage, medianHist,
                    "Зашумленное изображение после медианного фильтра").Show();
            }

            //show media-Filter RGB greyscale image

            if (checkBoxMediumG.Checked)
            {
                new Image(medianGraeyImage, medianGraeyHist,
                    "Зашумленное grayScale изображение после медианного фильтра").Show();
            }
            //show ??? RGB image
            if (checkBoxAVG.Checked)
            {
                new Image(avgImage, avgHist, "Изображение после фильтр «гармоническое среднее»").Show();
            }
            //show ??? greyscale image
            if (checkBoxAVGG.Checked)
            {
                new Image(avgGraeyImage, avgGraeyHist, 
                    "Изображение greyscale после фильтр «гармоническое среднее»").Show();
            }

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox check = (CheckBox)sender;
            if (check.CheckState != CheckState.Indeterminate)
            {
                flag = false;
                checkBoxG.Checked = check.Checked;
                checkBoxRGB.Checked = check.Checked;
                flag = true;
            }
        }

        private void checkBoxRGB_G_CheckStateChanged(object sender, EventArgs e)
        {

            CheckBox check = (CheckBox)sender;


            if (check.CheckState != CheckState.Indeterminate)
            {
                if (check.Equals(this.checkBoxRGB))
                {
                    RGB = false;
                    checkBoxIm.Checked = checkBoxRGB.Checked;
                    checkBoxNegativ.Checked = checkBoxRGB.Checked;
                    checkBoxNoise.Checked = checkBoxRGB.Checked;
                    checkBoxMedium.Checked = checkBoxRGB.Checked;
                    checkBoxAVG.Checked = checkBoxRGB.Checked;
                    RGB = true;
                }

                if (check.Equals(this.checkBoxG))
                {
                    Grey = false;
                    checkBoxImG.Checked = checkBoxG.Checked;
                    checkBoxNegativG.Checked = checkBoxG.Checked;
                    checkBoxNoiseG.Checked = checkBoxG.Checked;
                    checkBoxMediumG.Checked = checkBoxG.Checked;
                    checkBoxAVGG.Checked = checkBoxG.Checked;
                    Grey = true;
                }
            }
            if (!flag) return;
            if (checkBoxRGB.CheckState == CheckState.Checked && checkBoxG.CheckState == CheckState.Checked)
            {
                checkBox3.CheckState = CheckState.Checked;
            }
            else if (checkBoxRGB.CheckState == CheckState.Unchecked && checkBoxG.CheckState == CheckState.Unchecked)
            {
                checkBox3.CheckState = CheckState.Unchecked;
            }
            else
            {
                checkBox3.CheckState = CheckState.Indeterminate;
            }


        }

        private void checkBoxRGB_CheckChanged(object sender, EventArgs e)
        {
            if (RGB)
            {
                if (checkBoxIm.Checked && checkBoxNegativ.Checked && checkBoxNoise.Checked &&
                  checkBoxAVG.Checked && checkBoxMedium.Checked)
                {
                    checkBoxRGB.CheckState = CheckState.Checked;
                }
                else if (!checkBoxIm.Checked && !checkBoxNegativ.Checked && !checkBoxNoise.Checked &&
                  !checkBoxAVG.Checked && !checkBoxMedium.Checked)
                {
                    checkBoxRGB.CheckState = CheckState.Unchecked;
                }
                else
                {
                    checkBoxRGB.CheckState = CheckState.Indeterminate;
                }
            }
        }

        private void checkBoxG_CheckChanged(object sender, EventArgs e)
        {
            if (Grey)
            {
                if (checkBoxImG.Checked && checkBoxNegativG.Checked && checkBoxNoiseG.Checked &&
                  checkBoxAVGG.Checked && checkBoxMediumG.Checked)
                {
                    checkBoxG.CheckState = CheckState.Checked;
                }
                else if (!checkBoxImG.Checked && !checkBoxNegativG.Checked && !checkBoxNoiseG.Checked &&
                  !checkBoxAVGG.Checked && !checkBoxMediumG.Checked)
                {
                    checkBoxG.CheckState = CheckState.Unchecked;
                }
                else
                {
                    checkBoxG.CheckState = CheckState.Indeterminate;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            execute();
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
        }
    }
}
