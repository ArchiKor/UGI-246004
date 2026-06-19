using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число элементов массива");
            var n = int.Parse(Console.ReadLine());

            if (n < 1)
            {
                Console.WriteLine("Слишком маленький массив.");
                return;
            }

            var numbers = new int[n];

            Console.WriteLine($"Введите {n} целых чисел:");
            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = int.Parse(Console.ReadLine());

            Console.WriteLine("Исходный массив:");
            PrintIntArray(numbers);

            Console.WriteLine("Введите множитель k:");
            var k = int.Parse(Console.ReadLine());
            MultiplyArray(numbers, k);
            Console.WriteLine("Массив после умножения на k:");
            PrintIntArray(numbers);

            var average = GetAverage(numbers);
            Console.WriteLine($"Среднее арифметическое элементов: {average:F6}\n");

            Console.WriteLine("Массив после обмена элементов:");
            PrintIntArray(ReversePairs(numbers));
        }

        static void PrintIntArray(int[] array)
        {
            foreach (var item in array)
                Console.Write($"{item} ");

            Console.WriteLine("\n");
        }

        static void MultiplyArray(int[] array, int k)
        {
            for (int i = 0; i < array.Length; i++)
                array[i] *= k;
        }

        static double GetAverage(int[] array)
        {
            if (array.Length == 0)
                return 0;

            double sum = 0;
            foreach (var item in array)
                sum += item;

            return sum / array.Length;
        }

        static int[] ReversePairs(int[] array)
        {
            var result = new int[array.Length];
            Array.Copy(array, result, array.Length);

            for (int i = 0; i < result.Length / 2; i++)
            {
                var temp = result[i];
                result[i] = result[result.Length - 1 - i];
                result[result.Length - 1 - i] = temp;
            }

            return result;
        }
    }
}
