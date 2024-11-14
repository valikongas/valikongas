using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_pamoka__paveldimumas_ir_Virtual_metod
{
    internal class Manager:Employee
    {
        public int Employees { get; set; }
        public Manager(int emplyees)
        {
            Employees = emplyees;
        }

        public void Printmetodas(string name,List<Programer> programeriai)
        {
            foreach (Programer programer in programeriai)
            {
                Console.WriteLine($"Vadovas {name} vadovauja programuotojui {programer.Name}, kuris programuoja kalba: {programer.ProgrammingLanguage}");
            }
        }

    }
}
