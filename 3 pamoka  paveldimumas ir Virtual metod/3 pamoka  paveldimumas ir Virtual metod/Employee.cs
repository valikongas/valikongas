using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_pamoka__paveldimumas_ir_Virtual_metod
{
    internal class Employee
    {
        public string Name { get; set; }
        public int Salary { get; set; }


        public virtual void Greeting(string vardas)
        {
            Console.WriteLine($"Sveiki pradejus darba {vardas}");
        }
    }

}
