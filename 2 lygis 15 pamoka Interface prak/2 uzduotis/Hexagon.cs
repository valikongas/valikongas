using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygis_15_pamoka_Interface_prak
{
    internal class Hexagon : CompareArea
    {


      
        public double Width { get ; set ; }//krastine

        public Hexagon(string name, double width)
        {
            Name = name ;
            Width = width ;

        }

      

        public override double GetArea()
        {
            return 3.0 * Math.Sqrt(3.0) / 2.0 * Width;
        }
    }
}
