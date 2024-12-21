using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygis_13_pamoka_Linq
{
    internal class Pet
    {
        public string Petname { get; set; }
        public int PetAge { get; set; }

        public Pet(string petname,int petage)
        {
            Petname = petname;
            PetAge = petage;
        }
        public Pet()
        {
            
        }
    }
}
