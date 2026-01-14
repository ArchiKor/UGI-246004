using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Введите натуральное число: ");
            int number = int.Parse(Console.ReadLine());

            Console.Write($"{number} = ");

            bool IsPrime(int n)
            {
                if (n < 2) return false;
                for (int i = 2; i * i <= n; i++)
                {
                    if (n % i == 0) return false;
                }
                return true;
            }

            bool uslovie = true;
            int del = 2;
            int originalNumber = number;

            while (number > 1)
            {
                if (number % del == 0 && IsPrime(del))
                {
                    int count = 0;

                    while (number % del == 0)
                    {
                        number /= del;
                        count++;
                    }

                    if (!uslovie)
                    {
                        Console.Write(" * ");
                    }

                    Console.Write(count == 1 ? $"{del}" : $"{del}^{count}");
                    uslovie = false;
                }
                del++;
            }

            if (originalNumber == 1)
            {
                Console.Write("1");
            }

            Console.WriteLine();
        }
    }
    }
    

