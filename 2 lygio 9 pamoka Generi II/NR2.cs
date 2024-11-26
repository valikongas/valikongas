using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygio_9_pamoka_Generi_II
{
    internal class NR2<T>
    {
        public List<T> Masyvas { get; set; }

        public NR2(List<T> values)
        {
            Masyvas = new List<T>(values);
        }

        public void PrintMasyvas()
        {
            foreach (var m in Masyvas)
            {
                Console.WriteLine(m);
            }
        }

        public T[] DuomenuMasyvas()
        {
            return Masyvas.ToArray();
        }

        public void AddMasyvas(T values)
        {
           
            Masyvas.Add(values);
        }

        public void RemoveMasyvas(T values)
        {
            
                Masyvas.Remove(values);
        }

        public void RemoveIndexMasyvas(int index)
        {
            
                Masyvas.RemoveAt(index);
        }

        public void RemoveAllMasyvas(T values)

        {
      
            
                for (int i = 0; i < Masyvas.Count; i++)
                    if (Equals(Masyvas[Masyvas.Count - 1 - i], values))
                    {
                        Masyvas.RemoveAt(Masyvas.Count - 1 - i);
                        i--;
                    }
          
        }


    }
}
