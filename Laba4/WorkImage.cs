using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Laba4
{
    class WorkImage
    {

        public List<Bitmap> list { get; set; }
        public List<double[]> vectors { get; set; }


        public List<Bitmap> noiseList { get; set; }
        public List<double[]> vectorsNoise { get; set; }

        string path = @"D:\Learn\4 курс\ЦОСиИ\DIP\Laba4\Image\";
        int N = 5;
        public WorkImage()
        {
            list = new List<Bitmap>();
            vectors = new List<double[]>();
            string aa = System.IO.Directory.GetCurrentDirectory();
            for (int i = 0; i < N; i++)
            {
                string fileName = path + (i + 1).ToString() + ".png";
                Bitmap image = new Bitmap(fileName);
                list.Add(image);
                vectors.Add(ItoD(image));
            }

        }

        private double[] ItoD(Bitmap image)
        {
            double[] im = new double[image.Width * image.Height];
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    im[x + y * image.Height] = (double)image.GetPixel(x, y).R;
                }
            }
            return im;
        }

        public void SetNoise(int percent)
        {
            
            noiseList = new List<Bitmap>();
            vectorsNoise = new List<double[]>();
            Random rand = new Random();
            int count = Convert.ToInt32(Convert.ToDouble(percent) / 100 * vectors[0].Length);
            for (int j = 0; j < list.Count; j++)
            {
                Bitmap image = new Bitmap(list[j]);
                List<Point> points = new List<Point>();
                for (int i = 0; i < count; i++)
                {
                    int x, y;
                    do
                    {
                        x = rand.Next(image.Width - 1);
                        y = rand.Next(image.Height - 1);
                    }
                    while (points.Contains(new Point(x, y)));
                    points.Add(new Point(x, y));
                    byte pixel = image.GetPixel(x, y).R;
                    pixel = (byte)(~pixel);
                    image.SetPixel(x, y, Color.FromArgb(pixel, pixel, pixel));
                    
                }
                noiseList.Add(image);
                vectorsNoise.Add(ItoD(noiseList[j]));
            }
        }

        public static Bitmap Zoom(Bitmap im, int n)
        {
            Bitmap newIm = new Bitmap(im.Width * n, im.Height * n);

            for(int i = 0; i < im.Width; i++)
            {
                for (int j = 0; j < im.Height; j++)
                {
                    Color c = im.GetPixel(i, j);
                    for (int i1 = 0; i1 < n; i1++)
                    {
                        for (int j1 = 0; j1 < n; j1++)
                        {
                            newIm.SetPixel(i * n + i1, j * n + j1, c);
                        }
                    }
                }
            }

            return newIm;
        }
    }
}
