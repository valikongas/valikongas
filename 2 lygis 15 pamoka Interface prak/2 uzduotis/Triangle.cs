using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygis_15_pamoka_Interface_prak
{
    internal class Triangle:CompareArea
    {


        public double Height { get; set; }// pagrindas
        public double Width { get; set; }//aukstine

        public Triangle(string name, double height, double width)
        {
            Name = name;
            Height = height;
            Width = width;

        }

        public override double GetArea()
        {
            return Height * Width / 2;
        }

    }
}
