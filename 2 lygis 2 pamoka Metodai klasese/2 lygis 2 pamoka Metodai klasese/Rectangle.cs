using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygis_2_pamoka_Metodai_klasese
{
    internal class Rectangle
    {
        public  double Height { get; set; }
        public double Width { get; set; }
        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public double Area()
        {  return Height * Width; }

        public double Perimeter()
        { return 2 * Height + 2 * Width; } 
    }
}
