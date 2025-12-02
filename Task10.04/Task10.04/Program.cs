using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10._04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число a");
            int a = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите последовательность целых чисел, оканчивающуюся нулем");

            int sum = 0;
            int number;

            do
            {
                number = int.Parse(Console.ReadLine());

                if (number > a)
                {
                    sum += number;
                }
            }
            while (number != 0);

            Console.WriteLine($"Сумма всех чисел последовательности, больших {a}: {sum}");
        }
    }
}
