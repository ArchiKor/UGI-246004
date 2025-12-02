using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10._02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество чисел n:");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите 1-е число");
            double past = double.Parse(Console.ReadLine());
            double maxZnach = 0;

            for (int k = 2; k <= n; k++)
            {
                Console.WriteLine($"Введите {k}-е число");
                double current = double.Parse(Console.ReadLine());

                double znach = Math.Abs(current - past);
                if (znach > maxZnach)
                {
                    maxZnach = znach;
                }

                past = current;
            }

            Console.WriteLine($"Максимальное значение |ak - a(k-1)| = {maxZnach:F4}");
        }
    }
}
