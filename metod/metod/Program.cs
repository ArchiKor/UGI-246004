using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
                Print("Hello world!");
                Print(42);
                Print("Сумма:", 10, 20);
            
               
        }

            /// <summary>
            /// Выводит строку на консоль.
            /// </summary>
            /// <param name="message">Строка для вывода.</param>
            static void Print(string message)
            {
                Console.WriteLine(message);
            }

            /// <summary>
            /// Выводит целое число на консоль.
            /// </summary>
            /// <param name="number">Целое число для вывода.</param>
            static void Print(int number)
            {
                Console.WriteLine($"Число: {number}");
            }

            /// <summary>
            /// Выводит сообщение и сумму двух чисел.
            /// </summary>
            /// <param name="prefix">Текст перед суммой.</param>
            /// <param name="a">Первое слагаемое.</param>
            /// <param name="b">Второе слагаемое.</param>
            static void Print(string prefix, int a, int b)
            {
                Console.WriteLine($"{prefix} {a + b}");
            }

           
        }
    }


    

