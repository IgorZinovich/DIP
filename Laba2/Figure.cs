using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Laba2
{
    class Figure
    {
        public Byte[][] map{get; private set;}

        private Double per;
        public Double Perimetr { get { return per; } }

        private Double den;

        public Double Density { get { return den; } }

        private Double elon;
        public Double Elongation { get { return elon; } }

        public Int32 minX { get; private set; }
        public Int32 maxX { get; private set; }
        public Int32 minY { get; private set; }
        public Int32 maxY { get; private set; }

        public Figure(Byte[][] map, int x, int y)
        {
            this.map = map;
            GetPerimetrAndSquare();
            printf(x.ToString() + y.ToString());

        }

        private void GetPerimetrAndSquare()
        {
            int square = 0;
            double xc = 0, yc = 0;
 
            for (int x = 0; x < map.Length; x++)
                for (int y = 0; y < map[x].Length; y++)
                    if (map[x][y] == 1)
                    {
                        square++;
                        xc += x;
                        yc += y;
                        if ((x == 0 || x == map.Length - 1 || y == 0 || y == map[x].Length - 1) ||
                            (map[x + 1][y] == 0 || map[x - 1][y] == 0 || map[x][y + 1] == 0 || map[x][y - 1] == 0))
                        {
                            per++;
                        }
                        if (x < minX) minX = x;
                        if (x > maxX) maxX = x;
                        if (y < minY) minY = y;
                        if (y > maxY) maxY = y;
                    }
            xc /= square;
            yc /= square;
            double m20 = 0, m02 = 0, m11 = 0;
            for (int x = 0; x < map.Length; x++)
                for (int y = 0; y < map[x].Length; y++)
                    if (map[x][y] == 1)
                    {
                        m11 += (x - xc) * (y - yc);
                        m20 += (x - xc) * (x - xc);
                        m02 += (y - yc) * (y - yc);
                    }
            den = per * per / square;
            elon = (m02 + m20 + Math.Sqrt(Math.Pow(m20 - m02, 2) + 4 * Math.Pow(m11, 2))) /
                (m02 + m20 - Math.Sqrt(Math.Pow(m20 - m02, 2) + 4 * Math.Pow(m11, 2)));
            
        }

        public void printf(String name)
        {
            StreamWriter sw = new StreamWriter(@"D:\" + name + ".txt");
            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    sw.Write(map[i][j].ToString());
                }
                sw.WriteLine();
            }
            sw.Close();
        }

        public void normalization(double perimetr, double elongation, double density)
        {
            den /= density;
            per /= perimetr;
            elon /= elongation;
        }

    }
}
