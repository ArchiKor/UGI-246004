using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var x = Calculate(1, Calculate(2, Calculate(3, Calculate(4, 0))));
            Console.WriteLine(Math.Round(x, 3));
        }

        static double Calculate(double a, double b) =>
            Math.Sin(a + b);
        
    }
}
