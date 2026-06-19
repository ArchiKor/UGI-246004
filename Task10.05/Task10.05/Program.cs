using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10._05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите натуральное число > 1000");
            long n = long.Parse(Console.ReadLine());

            long result = 0;

            while (n > 0)
            {
                long digit = n % 10;

                if (digit % 2 != 0)
                {
                    result = result * 10 + digit;
                }

                n /= 10;
            }

            Console.WriteLine($"Результат: {result}");
        }
    }
}
