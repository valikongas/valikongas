using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygis_15_pamoka_Interface_prak
{
    internal class Cat : IAnimal, IMammal, IComparable<Cat>
    {
        public string Name { get; set; }
        public int Weight { get; set; }

        public Cat(string name, int weight)
        {
            Name = name;
            Weight = weight;
        }
        public void Eat()
        {
            Console.WriteLine("Katinas valgo");
        }
        public int CompareTo(Cat obj)
        {
            return string.Compare(Name, obj.Name, StringComparison.Ordinal);
        }
        public void GiveBirth()
        {
            Console.WriteLine("katinas gimsta");
        }
    }
}
