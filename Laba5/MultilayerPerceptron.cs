using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba5
{
    class MultilayerPerceptron
    {
        private double[][] v, w;
        private double[] Q, T;
        private double alpha = 2, beta = 2;
        private int n, h, m;
        private double D;
        public bool accur { get; private set; }
        Random rand = new Random();


        double f(double x)
        {
            return 1.0 / (1.0 + Math.Pow(Math.E, -1.0 * x));
        }

        public MultilayerPerceptron(double alpha, double beta, double D, int n = 36, int m = 5, int h = 0)
        {
            accur = true;
            this.alpha = alpha;
            this.beta = beta;
            this.D = D;
            this.n = n;
           
            this.m = m;
            this.h = (m + n) / 2;

            Q = new double[this.h];
            T = new double[m];
            
            v = new double[n][];
            for(int i = 0; i < n; i++ )
            {
                v[i] = new double[this.h];
                for(int j = 0; j <this.h; j++)
                {
                    v[i][j] = rand.Next(0, 2) == 0 ? rand.NextDouble() : -1.0 * rand.NextDouble();
                }
                
            }

            for(int i =0; i < this.h; i++)
            {
                Q[i] = rand.Next(0, 2) == 0 ? rand.NextDouble() : -1.0 * rand.NextDouble();
            }

            w = new double[this.h][];
            for (int i = 0; i < this.h; i++)
            {
                w[i] = new double[m];
                for (int j = 0; j < m; j++)
                {
                    w[i][j] = rand.Next(0, 2) == 0 ? rand.NextDouble() : -1.0 * rand.NextDouble();
                }
            }
            for(int i = 0; i< T.Length; i++)
            {
                T[i] = rand.Next(0, 2) == 0 ? rand.NextDouble() : -1.0 * rand.NextDouble();
            }

        }

        private double[] getLayer(double[] x, double[] QT, double[][] vw)
        {
            double[] g = new double[QT.Length];

            for(int j = 0; j < QT.Length; j++)
            {
                double sum = 0;
                for(int i = 0; i < x.Length; i++)
                {
                    sum += vw[i][j] * x[i];
                }
                g[j] = f(sum + QT[j]);
            }
            return g;
        }

        /*private double multi(double[] x, double[] y)
        {
            double sum = 0;
            for(int i = 0; i< x.Length; i++)
            {
                sum += x[i] * y[i
            }
            return sum;
        }*/

        private double[] getDk(double[] yr, double[] y)
        {
            double[] d = new double[y.Length];

            for(int k = 0; k < y.Length; k++)
            {
                d[k] = yr[k] - y[k];
            }

            return d;
        }

        public void learn(List<double[]> images, List<double[]> clust)
        {
            double dmin = double.MaxValue;
            int pp = 0;
            do
            {
                dmin = 0;
                foreach (var image in images)
                {
                    double[] g = getLayer(image, Q, v);
                    double[] y = getLayer(g, T, w);

                    double[] dk = getDk(clust[images.IndexOf(image)], y);

                    int idx = Array.IndexOf(clust[images.IndexOf(image)], 1.0);
                    if (dk[idx] > dmin)
                    {
                        dmin = dk[idx];
                    }

                    //поправка выходных коэффициентов
                    for (int k = 0; k < dk.Length; k++)
                    {
                        for (int j = 0; j < g.Length; j++)
                        {
                            w[j][k] += alpha * y[k] * (1 - y[k]) * dk[k] * g[j];
                        }
                        T[k] += alpha * y[k] * (1 - y[k]) * dk[k];
                    }

                    //поправка скрытого слоя
                    double[] e = new double[w.Length];
                    for (int j = 0; j < w.Length; j++)
                    {
                        e[j] = 0;
                        for (int k = 0; k < dk.Length; k++)
                        {
                            e[j] += dk[k] * y[k] * (1 - y[k]) * w[j][k];
                        }
                    }
                    // сама поправка
                    for (int j = 0; j < Q.Length; j++)
                    {
                        for (int i = 0; i < v.Length; i++)
                        {
                            v[i][j] += beta * g[j] * (1 - g[j]) * e[j] * image[i];
                        }
                        Q[j] += beta * g[j] * (1 - g[j]) * e[j];
                    }
                }
                if(pp++ == 100000)
                {
                    accur = false;
                    break;
                }
            } while (dmin > D );
            Console.WriteLine(dmin);
        }


        public double[] getCluster(double[] x)
        {
            return getLayer(getLayer(x, Q, v), T, w);
        }
    }
}
