using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapes;
using System.Drawing;
namespace ShapesApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var p = new Shapes.point(2, 5, Color.Blue);
            Console.WriteLine(p);

            var circle = new Circle(p, 3, Color.LightGreen, Color.Green);
            Console.WriteLine(circle);
        }
    }
}
