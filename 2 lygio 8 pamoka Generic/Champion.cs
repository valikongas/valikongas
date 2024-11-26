using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygio_8_pamoka_Generic
{
    internal class Champion<T> where T : Comand
    {
        public List<T> ComandList = new ();

        


        public void PrintComandList()
        {
            foreach (var item in ComandList)
            { 
                Console.WriteLine(item.Name); 
            }
        }

        public void AddComandList(T item)
        {
           
           
            
                ComandList.Add(item); 
           




        }
    }

}
