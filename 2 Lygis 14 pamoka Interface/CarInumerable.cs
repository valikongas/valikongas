using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Lygis_14_pamoka_Interface
{
    internal class CarInumerable : IComparer<Car>
    {
        public int Compare(Car? x, Car? y)
        {
            if(x.Fuel<y.Fuel)
                return -1;
            else if (x.Fuel==y.Fuel)
                return 0;
            else return 1;
        }
    }
}
