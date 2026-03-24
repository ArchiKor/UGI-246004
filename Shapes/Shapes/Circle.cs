using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Shapes
{
    public class Circle
    {
        public point Centre;
        public int Radius;

        public Color FillColor;

        public Color OutlineColor;
    
        public Circle(point centre, int radius, Color fillColor, Color outlineColor)
        {
            Centre = centre;
            Radius = radius;
            FillColor = fillColor;
            OutlineColor = outlineColor;
        }

        public override string ToString() => $"круг с центром в точке {Centre} радиуса {Radius}";
       
    }

}
