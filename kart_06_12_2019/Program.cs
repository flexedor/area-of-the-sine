using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kart_06_12_2019
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wpisz liczbę wątków:");
            int liczba_wątków = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Wpisz x_początkowe:");
            double x_początkowe = Double.Parse(Console.ReadLine());

            Console.WriteLine("Wpisz x_ostatnie:");
            double x_ostatnie = Double.Parse(Console.ReadLine());

            Console.WriteLine(Wątki_Sin(x_początkowe, x_ostatnie, 100000, liczba_wątków));
            Console.ReadKey();
        }
        public static double Sin(double x1, double x2, int n)
        {
            Random rand = new Random();

            double x, y;
            double s = 0;
            double licz1 = 0;
            double licz2 = 0;
            for (int i = 0; i < n; ++i)
            {
                x = rand.NextDouble() * (x2 - x1) + x1;
                y = rand.NextDouble() * (2) - 1;
                if (Math.Cos(x) >= 0)
                {
                    if ((y <= Math.Cos(x) && y >= 0)) licz1++;
                }
                else
                if (Math.Cos(x) < 0)
                {
                    if ((y > Math.Cos(x) && y < 0)) licz2++;
                }


            }
            s = ((x2 - x1) * 2) * ((licz1 - licz2)) / n;
            return s;
        }
        public static double Wątki_Sin(double x1, double x2, int n, int w)
        {
            double[] res = new double[n];
            double odc = (x2 - x1) / w;
            Parallel.For(0, w, (long g) =>
            {
                res[g] = Sin(x1 + g * odc, x1 + g * odc + odc, n);
            });
            return res.Sum();
        }
  

    }
}
