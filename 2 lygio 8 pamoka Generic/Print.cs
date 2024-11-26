using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygio_8_pamoka_Generic
{
    internal class Print<T1,T2>
    {
        public T1 FirstCons { get; set; }
        public T2 SecondCons { get; set; }
        public Print() { }

        public Print(T2 secondname)
        {
            SecondCons = secondname;
        }
        public Print(T1 firsname)
        {
            FirstCons = firsname;
        }
        public Print(T1 firsname, T2 secondname)
        {
            FirstCons = firsname;
            SecondCons = secondname;
        }

        public void ChangeFirstCons(T1 firsname)
        {
            FirstCons = firsname;
        }

        public void ChangeSecondCons(T2 secondname)
        {
            SecondCons = secondname;
        }

        public void PrintFirstCons()
        {
            Console.WriteLine("Pirmasis kintamasis yra: " + FirstCons);
        }
        public void PrintSecondCons()
        {
            Console.WriteLine("Antrasis kintamasis yra: " + SecondCons);
        }
    }
}
