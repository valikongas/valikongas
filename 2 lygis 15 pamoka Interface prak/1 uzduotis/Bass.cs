using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygis_15_pamoka_Interface_prak
{
    internal class Bass : IAnimal, IFish,IComparable<Bass>
    {
        public string Name { get; set; }
        public int Weight { get ; set; }

        public Bass(string name, int weight)
        {
            Name = name;
            Weight = weight;
        }

        public int CompareTo(Bass obj)
        {
            return string.Compare(Name, obj.Name, StringComparison.Ordinal);
        }
            
        

        public void Eat()
        {
            Console.WriteLine("Eserys valgo");
        }

        public void Swim()
        {
            Console.WriteLine("Eserys plaukia");
        }

    
    }
}
