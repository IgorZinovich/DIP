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
        struct MyPoint
        {
            public Double x;
            public Double y;

            public MyPoint(Double x, Double y)
            {
                this.x = x;
                this.y = y;
            }
            public MyPoint(MyPoint source)
            {
                x = source.x;
                y = source.y;
            }
            public Double GetDistance(Double x, Double y)
            {
                return Math.Sqrt(Math.Pow(this.x - x, 2) + Math.Pow(this.y - y, 2));
            }
            public override bool Equals(object obj)
            {
                MyPoint temp = (MyPoint)obj;
                if(x == temp.x && y == temp.y)
                {
                    return true;
                }
                return false;
            }

            public void NewCenter(List<Figure> list)
            {
                Double x = 0;
                Double y = 0;
                foreach(var item in list)
                {
                    x += item.Perimetr;
                    y += item.Elongation;
                }
                this.x = x / list.Count;
                this.y = y / list.Count;
            }
            
        }
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
        public static List<Figure> GetFigure(Bitmap image)
        {
            List<Figure> figures = new List<Figure>();
            for (int x = 0; x < image.Width; x++)
            {

                for (int y = 0; y < image.Height; y++)
                {

                    if (image.GetPixel(x, y).R == 255)
                    {
                        byte[][] figure = fillBlack(image.Width, image.Height);
                        func1(image, x, y, ref figure);
                        figures.Add(new Figure(figure));
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
        public static List<Figure>[] Clustarization(List<Figure> list, int count)
        {
            Double maxP = 0;
            foreach(var item in list)
            {
                if (maxP < item.Perimetr)
                    maxP = item.Perimetr;
            }
            Random rand = new Random();
            MyPoint[] clustCenter = new MyPoint[count];
            List<Figure>[] clust = new List<Figure>[count];
            MyPoint[] check = new MyPoint[count];
            for(int i =0; i< count; i++)
            {
                clustCenter[i] = new MyPoint(Convert.ToDouble(rand.Next(Convert.ToInt32(maxP + 1))), rand.NextDouble());
                clust[i] = new List<Figure>();
                
            }
            
            //MyPoint clust2Center = new MyPoint(Convert.ToDouble(rand.Next(Convert.ToInt32(maxP + 1))), rand.NextDouble());
            bool flag = true;
            while (flag)
            {
                for(int j = 0; j< clustCenter.Count(); j++)
                {
                    check[j] = new MyPoint(clustCenter[j]);
                }
                foreach(var clustItem in clust)
                {
                    clustItem.Clear();
                }
                foreach (var figure in list)
                {
                    List<Double> dist = new List<Double>();
                    foreach(var center in clustCenter)
                    {
                        dist.Add(center.GetDistance(figure.Perimetr, figure.Elongation));
                    }
                    clust[dist.IndexOf(dist.Min())].Add(figure);
                }
                int i = 0;
                foreach (var center in clustCenter)
                {
                    center.NewCenter(clust[i]);
                    i++;
                }
                i = 0;
                flag = false;
                foreach (var center in clustCenter)
                {
                    if (!center.Equals(check[i]))
                    {
                        flag = true;
                        break;
                    }
                    i++;
                }
                
            }
            return clust;
        }
    }
}
