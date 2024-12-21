using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygis_15_pamoka_Interface_prak
{
    internal class Carp : IAnimal, IFish,IComparable<Carp>
    {
        public string Name { get; set; }
        public int Weight { get; set; }

        public Carp(string name, int weight)
        {
            Name = name;
            Weight = weight;
        }

        public void Eat()
        {
            Console.WriteLine("Karpis valgo"); ;
        }
        public int CompareTo(Carp obj)
        {
            return string.Compare(Name, obj.Name, StringComparison.Ordinal);
        }
        public void Swim()
        {
            Console.WriteLine("Karpis plaukia"); ;
        }
    }
}
