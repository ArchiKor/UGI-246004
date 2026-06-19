using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10._03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите e > 0");
            var epsilon = double.Parse(Console.ReadLine());

            long prevNumerator = 1;
            long prevDenominator = 1;
            double prevFraction = 1.0;

            long currentNumerator = 2;
            long currentDenominator = 1;
            double currentFraction = 2.0;

            int n = 2;

            while (Math.Abs(currentFraction - prevFraction) > epsilon)
            {
                long nextNumerator = currentNumerator + prevNumerator;
                long nextDenominator = currentDenominator + prevDenominator;
                double nextFraction = (double)nextNumerator / nextDenominator;

                prevNumerator = currentNumerator;
                prevDenominator = currentDenominator;
                prevFraction = currentFraction;

                currentNumerator = nextNumerator;
                currentDenominator = nextDenominator;
                currentFraction = nextFraction;

                n++;
            }

            Console.WriteLine($"Первый член, отличающийся от предыдущего не более чем на {epsilon}: {currentFraction} (номер {n})");
        }
    }
}
