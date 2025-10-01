using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите трехзначное число");

            var n = int.Parse(Console.ReadLine());

            var hundreds = n / 100;
            var tenthsAndUnits = n % 100;
            var tenths = tenthsAndUnits / 10;
            var units = tenthsAndUnits % 10;

            var result = tenths * 100 + hundreds * 10 + units;

            Console.WriteLine("Результат: " + result);
        }
    }
}
