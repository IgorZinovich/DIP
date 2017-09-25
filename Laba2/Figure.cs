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
        private Byte[][] map;

        private Int32 per;
        public Double Perimetr { get { return Convert.ToDouble(per); } }

        private Double elon;
        public Double Elongation { get { return elon; } }

        public Int32 minX { get; private set; }
        public Int32 maxX { get; private set; }
        public Int32 minY { get; private set; }
        public Int32 maxY { get; private set; }

        public Figure(Byte[][] map)
        {
            this.map = map;
            GetPerimetr();
            GetElongation();

        }

        private void GetPerimetr()
        {
            minX = map.Length;
            minY = map[0].Length;
            maxX = 0;
            maxY = 0;
            for (int x = 0; x < map.Length; x++)
                for (int y = 0; y < map[x].Length; y++)
                    if (map[x][y] == 1)
                    {
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

        }

        private void GetElongation()
        {
            elon = (Convert.ToDouble(maxX - minX) / Convert.ToDouble(maxY - minY)) > 1.0 ?
                Convert.ToDouble(maxX - minX) / Convert.ToDouble(maxY - minY) :
                Convert.ToDouble(maxY - minY) / Convert.ToDouble(maxX - minX);
        }
        public void printf()
        {
            StreamWriter sw = new StreamWriter(@"D:\444.txt");
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

    }
}
