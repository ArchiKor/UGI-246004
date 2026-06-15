using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Shapes
{
    public class point
    {
        public int X;
        public int Y;

        public Color Colour;
        public point(int x, int y, Color color)
        { 
           X = x;
           Y = y;
            Colour = color;

        }

        public override string ToString() => $"({X} {Y})";
        
    }
}
