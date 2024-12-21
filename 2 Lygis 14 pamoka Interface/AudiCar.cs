using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Lygis_14_pamoka_Interface
{
    internal class AudiCar:Car
    {
        public bool  IsQuattro{ get; set; }

        public AudiCar(bool isQuattro, string model, int fuel, int maxfuel)
        {
            IsQuattro = isQuattro;
            Model = model;
            Fuel = fuel;
            MaxFuel = maxfuel;
        }

    }
}
