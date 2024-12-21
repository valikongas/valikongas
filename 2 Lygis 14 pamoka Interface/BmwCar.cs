using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Lygis_14_pamoka_Interface
{
    internal class BmwCar:Car
    {
        public bool IsXDrive { get; set; }

        public BmwCar(bool isXDrive, string model, int fuel, int maxFuel )
        {
            IsXDrive = isXDrive;
            Model = model;
            Fuel = fuel;
            MaxFuel = maxFuel;
        }
    }
}
