using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Lygis_14_pamoka_Interface
{
    abstract class Car : IVehicle
    {
        public string Model { get; set; }
        public int Fuel { get; set; }
        public int MaxFuel { get; set; }

        public bool Drive()
        {
            if (Fuel>0)
            { return true; }
            else
            { return false; }
        }

        public bool Refuel(int refuel)
        {
            if(refuel>0 && MaxFuel>refuel)
                return true;
            else
                return false;
        }
    }
}
