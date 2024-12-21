using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Lygis_14_pamoka_Interface
{
    internal   class testas
    {
        public void Xestas(IVehicle vehicle)
        {
           bool z= vehicle.Drive();
            Console.WriteLine(z);
            
        }


    }
}
