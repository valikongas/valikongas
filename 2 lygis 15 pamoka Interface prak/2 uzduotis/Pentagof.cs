using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygis_15_pamoka_Interface_prak
{
    internal class Pentagof : CompareArea
    {



        public double Width { get; set; }//krastine

        public Pentagof(string name, double width)
        {
            Name = name;
            Width = width;

        }

   
        public override double GetArea()
        {
            return 1.0 / 4.0 * Math.Sqrt(5.0 * (5.0 + 2.0 * Math.Sqrt(5.0))) * Width; ;
        }
    }
}
