using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygio_8_pamoka_Generic
{
    internal class Type<T1,T2>
    {
        public T1 First { get; set; }
        public T2 Second { get; set; }

        public Type(T1 first, T2 second)
        {
            First = first;
            Second = second;
        }

        public void GetType ()
        {
            Console.WriteLine($"Pirmojo domens tipas {First.GetType()}, antrojo domens tipas {Second.GetType()}");
        }


    }
}
