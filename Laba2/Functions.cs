using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Laba2
{
    class Functions
    {

        static public Bitmap openImage(string name)
        {
            Bitmap map = new Bitmap(name);
            return map;
        }

        public static Bitmap Binarization(Bitmap image, double bounds)
        {
            Bitmap newImage = new Bitmap(image.Width, image.Height);
            for (int row = 0; row < image.Width; row++)
            {
                for (int column = 0; column < image.Height; column++)
                {
                    var colorValue = image.GetPixel(row, column);
                    double averageValue = ((0.3 * (int)colorValue.R + 0.11 * (int)colorValue.B + 0.59 * (int)colorValue.G)) < bounds ? 0 : 255;
                    newImage.SetPixel(row, column, Color.FromArgb((int)averageValue, (int)averageValue, (int)averageValue));
                }
            }
            return newImage;
        }

        public static int Perimetr(byte[][] figure)
        {
            
            Int32 count = 0;
            for (int x = 0; x < figure.Length; x++)
            {    
                 for (int y = 0; y < figure[x].Length; y++)
                 {
                     
                     if (figure[x][y]==1)
                     {
                         {
                             if((x == 0 || x == figure.Length - 1 || y == 0 || y == figure[x].Length -1) ||
                                 (figure[x+1][y]==0 || figure[x-1][y]==0 || figure[x][y+1]==0 || figure[x][y-1]==0))
                             {
                                 count++;
                             }
                         }
                     }
                 }
            }
                
            return count;
        }

        public static List<byte[][]> GetFigure(Bitmap image)
        {
            List<byte[][]> figures = new List<byte[][]>();
            for (int x = 0; x < image.Width; x++)
            {

                for (int y = 0; y < image.Height; y++)
                {

                    if (image.GetPixel(x, y).R == 255)
                    {
                        byte[][] figure = fillBlack(image.Width, image.Height);
                        func1(image, x, y, ref figure);
                        figures.Add(figure);
                    }
                }
            }

            return figures;
        }


        private static void func1(Bitmap map,int x, int y, ref byte[][] figure)
        {
            map.SetPixel(x, y, Color.FromArgb(0, 0, 0));
            figure[x][y] = 1;
            if (x > 0)
                if (map.GetPixel(x - 1, y).R == 255)
                {
                    func1(map, x - 1, y, ref figure);
                }
            if (y > 0)
                if (map.GetPixel(x, y - 1).R == 255)
                {
                    func1(map, x, y - 1, ref figure);
                }
            if (x < map.Width - 1)
                if (map.GetPixel(x + 1, y).R == 255)
                {
                    func1(map, x + 1, y, ref figure);
                }
            if (y < map.Height - 1)
                if (map.GetPixel(x, y + 1).R == 255)
                {
                    func1(map, x, y + 1, ref figure);
                }

        }
        private static byte[][] fillBlack(int x, int y)
        {
            byte[][] temp = new byte[x][];
            for (int i = 0; i < x; i++)
            {
                temp[i] = new byte[y];
                for (int j = 0; j < y; j++)
                {
                    temp[i][j] = 0;
                }
            }
            return temp;
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
                    R.Sort();
                    G.Sort();
                    B.Sort();
                    newImage.SetPixel(x, y, Color.FromArgb(R[R.Count/2], G[G.Count/2],
                        B[B.Count/2]));

                }
            }
            return newImage;
        }
    }
}
