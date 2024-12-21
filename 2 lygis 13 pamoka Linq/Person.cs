using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygis_13_pamoka_Linq
{
    internal class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

       
       public List<Pet> Pets ; 
        public Person(string name, int age, List<Pet> pets)
        {
            Name = name;
            Age = age;
            Pets = pets;
        }
    }
}
