using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygis_15_pamoka_Interface_prak
{
    internal class Quadrilateral:CompareArea
    {



        public double Width { get; set; }//krastine

        public Quadrilateral(string name, double width)
        {
            Name = name;
            Width = width;

        }

        public override double GetArea()
        {
            return Width*Width;
        }

    }
}
