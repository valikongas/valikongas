using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_pamoka__paveldimumas_ir_Virtual_metod
{
    internal class Programer:Employee
    {
        public string ProgrammingLanguage { get; set; } = "C#";

        public Programer(string name, int salary, string programmingLanguage)
        {
            Name = name;
            Salary = salary;
            ProgrammingLanguage = programmingLanguage;
        }

        public override void Greeting(string vardas)
        {
            base.Greeting(vardas);
            Console.WriteLine("Galesi dabar ismokti daugiau programavimo kalbu");
        }


    }
}
