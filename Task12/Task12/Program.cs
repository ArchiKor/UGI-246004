using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int m = 0, n = 0;

            while (true)
            {
                Console.WriteLine("Введите через пробел два натуральных числа m и n от 5 до 20");
                Console.WriteLine("(Enter - отказ от ввода)");
                var input = Console.ReadLine();

                if (input == string.Empty)
                    return;

                var strings = input.Split();

                if (strings.Length == 2 && int.TryParse(strings[0], out m) &&
                    int.TryParse(strings[1], out n) && 5 <= m && m <= 20 &&
                    5 <= n && n <= 20)
                    break;
                else
                {
                    Console.WriteLine("Ошибка ввода");
                    continue;
                }
            }


            var matrix = new int[m, n];

            var rnd = new Random();

            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] = rnd.Next(0, 100);

            Console.WriteLine();
            PrintTable(matrix);
            Console.WriteLine();

            Console.WriteLine("Проверка элементов на вхождение в интервал");
            int a = 0, b = 0;

            while (true)
            {
                Console.WriteLine("Введите границы интервала (a b):");
                var intervalInput = Console.ReadLine();

                if (intervalInput == string.Empty)
                    break;

                var intervalParts = intervalInput.Split();

                if (intervalParts.Length == 2 &&
                    int.TryParse(intervalParts[0], out a) &&
                    int.TryParse(intervalParts[1], out b) &&
                    a < b)
                    break;
                else
                {
                    Console.WriteLine("Ошибка ввода. Убедитесь что a < b");
                    continue;
                }
            }

            var checkResult = CheckInterval(matrix, a, b);

            if (checkResult.allInInterval)
            {
                Console.WriteLine($"Все элементы матрицы находятся в интервале ({a}, {b})");
            }
            else
            {
                Console.WriteLine($"Не все элементы матрицы находятся в интервале ({a}, {b})");
                Console.WriteLine($"Пример элемента, нарушающего условие: " +
                    $"matrix[{checkResult.row}, {checkResult.col}] = {matrix[checkResult.row, checkResult.col]}");
            }

            Console.WriteLine();

            Console.WriteLine("Максимальные элементы в каждом столбце");
            var maxInColumns = GetMaxInColumns(matrix);

            for (int j = 0; j < maxInColumns.Length; j++)
            {
                Console.WriteLine($"Столбец {j}: макс элемент = {maxInColumns[j]}");
            }
        }

        static void PrintTable(int[,] table)
        {
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                    Console.Write($"{table[i, j],2} ");

                Console.WriteLine();
            }
        }

        static (bool allInInterval, int row, int col) CheckInterval(int[,] table, int a, int b)
        {
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {

                    if (table[i, j] <= a || table[i, j] >= b)
                    {
                        return (false, i, j);
                    }
                }
            }
            return (true, -1, -1);
        }

        static int[] GetMaxInColumns(int[,] table)
        {
            int columns = table.GetLength(1);
            int rows = table.GetLength(0);
            int[] maxValues = new int[columns];

            for (int j = 0; j < columns; j++)
            {
                maxValues[j] = int.MinValue;
            }

            for (int j = 0; j < columns; j++)
            {
                for (int i = 0; i < rows; i++)
                {
                    if (table[i, j] > maxValues[j])
                    {
                        maxValues[j] = table[i, j];
                    }
                }
            }

            return maxValues;
        }
    }
}
