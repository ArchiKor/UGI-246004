using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите координаты центра квадрата:");
            var xc = double.Parse(Console.ReadLine());
            var yc = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите координаты вершины квадрата:");
            var xv = double.Parse(Console.ReadLine());
            var yv = double.Parse(Console.ReadLine());

            double diagonal = Math.Sqrt((xv - xc) * (xv - xc) + (yv - yc) * (yv - yc));

            double storona = diagonal * Math.Sqrt(2);

            var area = storona * storona;

            var perimeter = storona * 4;

            Console.WriteLine("Площадь квадрата равна " + area);
            Console.WriteLine("Периметр квадрата равен " + perimeter);


        }
    }
}
