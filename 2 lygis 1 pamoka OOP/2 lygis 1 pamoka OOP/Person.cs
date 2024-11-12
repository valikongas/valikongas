using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygis_1_pamoka_OOP
{
    internal class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Height { get; set; }
        public Adress PersonAdress { get; set; }

        public Person(double height)
        {
            Height = height;
        }
        public Person() { }

        public Person(string name, int age, double height)
        {
            Name = name;
            Age = age;
            Height = height;
        }
    }
}
