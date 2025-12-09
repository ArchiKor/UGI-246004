using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10._06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите верхнюю границу a для x, y, z:");

            if (!int.TryParse(Console.ReadLine(), out int a) || a < 1)
            {
                Console.WriteLine("Ошибка: введите натуральное число ≥ 1.");
                return;
            }

            Console.WriteLine($"\nПифагоровы тройки (x^2 + y^2 = z^2) для чисел <= {a}:");
            Console.WriteLine("x\ty\tz\tx^2\ty^2\tz^2");
            Console.WriteLine(new string('-', 50));

            int count = 0;

            for (int z = 3; z <= a; z++)
            {
                int zSquared = z * z;

                for (int x = 1; x < z; x++)
                {
                    int xSquared = x * x;

                    for (int y = x + 1; y < z; y++)
                    {
                        if (xSquared + y * y == zSquared && y <= a)
                        {
                            count++;
                            Console.WriteLine($"{x}\t{y}\t{z}\t{xSquared}\t{y * y}\t{zSquared}");
                        }
                    }
                }
            }

            Console.WriteLine(new string('-', 50));
            Console.WriteLine($"Всего найдено: {count} пифагоровых троек.");

           
        }
    }
}
