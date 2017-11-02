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

        List<Bitmap> list { get; set; }
        string path = @"C:\Users\Asus\Pictures\laba4\";
        int N = 5;
        public WorkImage()
        {
            list = new List<Bitmap>();
            for(int i = 0; i < N; i++)
            {
                string fileName = path + (i + 1).ToString() + ".png";
                Bitmap image = new Bitmap(fileName);
                list.Add(image);
            }
        }

        public List<double[]> ItoB()
        {
            List<double[]> vectors = new List<double[]>();
            foreach (var item in list)
            {
                double[] image = new double[item.Width * item.Height];
                for (int y = 0; y < item.Height; y++)
                {
                    for (int x = 0; x < item.Width; x++)
                    {
                        image[x + y * item.Height] = (double)item.GetPixel(x, y).R;
                    }
                }
                vectors.Add(image);
            }
            return vectors;
        }


    }
}
