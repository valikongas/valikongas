using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygio_8_pamoka_Generic
{
    internal class FourSideGeometricFigure:Generator<FourSideGeometricFigure>
    {
        public string Name { get; set; }
        public int Base1 { get; set; }
        public int Height { get; set; }

        public FourSideGeometricFigure()
        {
            
        }
        public FourSideGeometricFigure(string name, int base1, int height)
        {
            Name = name;
            Base1 = base1;
            Height = height;
        }
public double  GetArea(int base1, int height)
        {
            return base1 * height; 
        }

        public override string ToString()
        {
            string aprasymas = "";
            aprasymas = $"Figura yra {Name}. Jos plotis {Base1}, o aukstis {Height}" +
                $". Jos plotas yra {GetArea(Base1, Height)}.";

        return aprasymas;
        }
               
    }

    internal class T
    {
    }
}
