using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите целое число k");
            var k = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите целое число n");
            var n = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите целое число m");
            var m = int.Parse(Console.ReadLine());
            if (IfLogicalExpressionTrue(k, n, m))
                Console.WriteLine("k, n, m - положительные и хотя бы одно четное");
            else
                Console.WriteLine("Либо одно из чисел не положительное," + "либо нет четного числа");
        }

        static bool IfLogicalExpressionTrue(int k, int n, int m) =>
            (k > 0 && m > 0 && n > 0) && (k % 2 == 0 || m % 2 == 0 || n % 2 == 0);
    }
}
