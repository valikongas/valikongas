using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Person
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
    }

protected void PrintInfo()
        {
            Console.WriteLine(Name + ": " + Age);
        }
}
