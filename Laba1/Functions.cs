using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Laba1
{
    class Functions
    {
        static public Bitmap openImage(string name)
        {
            Bitmap map = new Bitmap(name);
            return map;
        }

        static public Int32[][] getHistRGB(Bitmap map)
        {
            Int32[][] rgb = { getHist(map, 0), getHist(map, 1), getHist(map, 2) };
            return rgb;
        }

        static public Int32[] getHistGrayScale(Bitmap map)
        {
            return getHist(map, 0);
        }

        static private Int32[] getHist(Bitmap map, Int32 type) // 0 - R 1 - G 2 - B
        {
            Int32[] hist = new Int32[map.Height * map.Width];
            int j = 0;
            foreach (var x in Enumerable.Range(0, map.Width))
            {
                foreach (var y in Enumerable.Range(0, map.Height))
                {
                    switch (type)
                    {
                        case 0: hist.SetValue(map.GetPixel(x, y).R, j++); break;
                        case 1: hist.SetValue(map.GetPixel(x, y).G, j++); break;
                        case 2: hist.SetValue(map.GetPixel(x, y).B, j++); break;
                        default: return null;
                    }

                }
            }
            Int32[] res = new Int32[256];
            hist = Merge_Sort(hist);
            j = 0;
            for (int i = 0; i < hist.Length; i++)
            {
                res[j] = 0;
                while (i < hist.Length && hist[i] == j)
                {
                    res[j]++;
                    i++;
                }
                j++;
            }
            return res;
        }

        static Int32[] Merge_Sort(Int32[] massive)
        {
            if (massive.Length == 1)
                return massive;
            Int32 mid_point = massive.Length / 2;
            return Merge(Merge_Sort(massive.Take(mid_point).ToArray()), Merge_Sort(massive.Skip(mid_point).ToArray()));
        }

        static Int32[] Merge(Int32[] mass1, Int32[] mass2)
        {
            Int32 a = 0, b = 0;
            Int32[] merged = new int[mass1.Length + mass2.Length];
            for (Int32 i = 0; i < mass1.Length + mass2.Length; i++)
            {
                if (b < mass2.Length && a < mass1.Length)
                    if (mass1[a] > mass2[b])
                        merged[i] = mass2[b++];
                    else //if int go for
                        merged[i] = mass1[a++];
                else
                    if (b < mass2.Length)
                        merged[i] = mass2[b++];
                    else
                        merged[i] = mass1[a++];
            }
            return merged;
        }

        public static Bitmap Negativ(Bitmap image)
        {

            Bitmap newImage = new Bitmap(image.Width, image.Height);
            foreach (var x in Enumerable.Range(0, image.Width))
            {
                foreach (var y in Enumerable.Range(0, image.Height))
                {
                    newImage.SetPixel(x, y, Color.FromArgb(255 - image.GetPixel(x, y).R,
                        255 - image.GetPixel(x, y).G, 255 - image.GetPixel(x, y).B));
                }
            }
            return newImage;
        }



        public static Bitmap Grayscale(Bitmap image)
        {
            Bitmap newImage = new Bitmap(image.Width, image.Height);
            for (int row = 0; row < image.Width; row++)
            {
                for (int column = 0; column < image.Height; column++)
                {
                    var colorValue = image.GetPixel(row, column);
                    var averageValue = (0.3 * (int)colorValue.R + 0.11 * (int)colorValue.B + 0.59 * (int)colorValue.G);
                    newImage.SetPixel(row, column, Color.FromArgb((int)averageValue, (int)averageValue, (int)averageValue));
                }
            }
            return newImage;
        }

        public static Bitmap median(Bitmap image, Int32 size)
        {
            Bitmap newImage = new Bitmap(image.Width, image.Height);

            List<int> R = new List<int>();
            List<int> G = new List<int>();
            List<int> B = new List<int>();

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    R.Clear();
                    G.Clear();
                    B.Clear();
                    Int32 finishY = ((y + size) < image.Height ? y + size : image.Height - 1);
                    Int32 finishX = ((x + size) < image.Width ? x + size : image.Width - 1);
                    for (int i = ((x - size) < 0 ? 0 : x - size); i <= finishX; i++)
                    {
                        for (int j = ((y - size) < 0 ? 0 : y - size); j <= finishY; j++)
                        {
                            R.Add(Convert.ToInt32(image.GetPixel(i, j).R));
                            G.Add(Convert.ToInt32(image.GetPixel(i, j).G));
                            B.Add(Convert.ToInt32(image.GetPixel(i, j).B));
                        }
                    }
                    newImage.SetPixel(x, y, Color.FromArgb((Merge_Sort(R.ToArray())[R.Count / 2]), (Merge_Sort(G.ToArray())[G.Count / 2]),
                        (Merge_Sort(B.ToArray())[B.Count / 2])));

                }
            }
            return newImage;
        }

        public static Bitmap avarage(Bitmap image)
        {
            Int32 size = 1;
            Bitmap newImage = new Bitmap(image.Width, image.Height);

            List<Double> R = new List<Double>();
            List<Double> G = new List<Double>();
            List<Double> B = new List<Double>();

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    R.Clear();
                    G.Clear();
                    B.Clear();
                    Int32 finishY = ((y + size) < image.Height ? y + size : image.Height - 1);
                    Int32 finishX = ((x + size) < image.Width ? x + size : image.Width - 1);
                    for (int i = ((x - size) < 0 ? 0 : x - size); i <= finishX; i++)
                    {
                        for (int j = ((y - size) < 0 ? 0 : y - size); j <= finishY; j++)
                        {
                            R.Add(1.0 / Convert.ToDouble(image.GetPixel(i, j).R));
                            G.Add(1.0 / Convert.ToDouble(image.GetPixel(i, j).G));
                            B.Add(1.0 / Convert.ToDouble(image.GetPixel(i, j).B));
                        }
                    }
                    Double r = R.Count / R.Sum(), g = G.Count / G.Sum(), b = B.Count / B.Sum();
                    newImage.SetPixel(x, y, Color.FromArgb((Int32)r, (Int32)g, (Int32)b));

                }
            }
            return newImage;
        }

        public static Bitmap noise(Bitmap image)
        {
            Bitmap newImage = (Bitmap)image.Clone();
            for (int i = 0; i < 20; i++)
            {
                Int32 x = i + 2;//new Random().Next(image.Width);
                Int32 y = 3;//new Random().Next(image.Height);
                newImage.SetPixel(x, y, Color.FromArgb(255, 255, 255));
            }
            return newImage;
        }
    }
}
