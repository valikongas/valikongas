using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygis_15_pamoka_Interface_prak
{
    internal abstract class CompareArea : IPlolygon, IComparable<CompareArea>
    {
        public double Area { get ; set ; }
        public string Name { get ; set ; }

        public int CompareTo(CompareArea? other)
        {
            if (Area > other.Area)
                return -1;
            else if (Area < other.Area)
                return 1;
            else return 0;

        }

        public abstract double GetArea();
       
    }
}
