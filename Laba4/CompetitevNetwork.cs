using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba4
{
    class CompetitevNetwork
    {
        readonly static int N = 36;
        readonly static int M = 5;
        readonly double beta = 0.01;
        double e = 0.01;
        int maxEpoh = 100000;
        double[][] w;
        int[] win = new int[M]; 

        public CompetitevNetwork()
        {
            Random rand = new Random();
            w = new double[M][];
            for(int i = 0; i< M; i++)
            {
                w[i] = new double[N];
                for(int j = 0; j < w[i].Length; j++)
                {
                    w[i][j] = rand.NextDouble();
                }
                w[i] = normirovka(w[i]);
                win[i] = 1;
            }
        }

        double rast(double[] a, double[]b)
        {
            double res = 0;
            for(int i =0;i<a.Length;i++)
            {
                res += Math.Pow(a[i] - b[i], 2);
            }

            return Math.Sqrt(res);
        }
        public int learn(List<double[]> images)
        {
            int epoha = 0;
            do
            {
                double maxRast = 0;
                foreach (var imagenn in images)
                {
                    double[] image = normirovka(imagenn);
                    int vinJ = 0;

                    double min = double.MaxValue;
                    for (int j = 0; j < w.Length; j++)
                    {
                        double sum = 0;
                        /*for (int i = 0; i < N; i++)
                        {
                            sum += image[i] * w[j, i];
                        }*/
                        sum = rast(image, w[j]) * win[j];
                        if (min > sum)
                        {
                            min = sum;
                            vinJ = j;
                        }
                        
                    }
                    win[vinJ]++;
                    Func1(vinJ, image);
                    if (rast(image, w[vinJ]) > maxRast)
                    {
                        maxRast = rast(image, w[vinJ]);
                    }
                }
                if(maxRast < e)
                {
                    break;
                }
                epoha++;
                Console.WriteLine(epoha.ToString()+"  -  "+maxRast.ToString());
            } while (epoha < maxEpoh);
            
            return 0;
        }

        double[] normirovka(double[] mas)
        {
            double[] nmas = new double[mas.Length];
            for(int i = 0; i < mas.Length; i++)
            {
                nmas[i] = mas[i] / mas.Sum();
            }
            return nmas;
        }

        void Func1(int j, double[] image)
        {
            for (int i = 0; i < N; i++)
            {
                w[j][i] = w[j][i] + beta * (image[i] - w[j][i]);
            }
            w[j] = normirovka(w[j]);
        }

        public int getCluster(double[] image)
        {
            int clusterNumber = 0;
            double max = 0;
            for(int j = 0; j < w.Length; j++)
            {
                double sum = 0;
                for (int i = 0; i < image.Length; i++)
                {
                    sum += Convert.ToDouble(image[i]) * w[j][i];
                }
                if(sum>max)
                {
                    max = sum;
                    clusterNumber = j;
                }
            }

            return clusterNumber;
        }
    }
}
