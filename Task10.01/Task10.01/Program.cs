using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10._01
{
    internal class Program
    {
            static void Main()
            {
                Console.Write("Введите число n: ");
                int n = int.Parse(Console.ReadLine());

                double step = Math.PI / n;
                double x = 0;
                double end = 2 * Math.PI;

                Console.WriteLine("x\t\tf(x)");
               

                while (x <= end)
                {
                    double result = Math.Sin(x);
                    Console.WriteLine($"{x:F4}\t\t{result:F4}");
                    x += step;
                }
            }
    }
}
