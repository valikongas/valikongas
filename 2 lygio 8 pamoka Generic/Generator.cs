using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygio_8_pamoka_Generic
{
    internal class Generator<T>
    {
        public void Show<T>(T obj) 
        {
            Console.WriteLine(obj);
        }
    }
}
