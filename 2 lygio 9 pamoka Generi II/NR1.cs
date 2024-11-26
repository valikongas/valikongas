using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygio_9_pamoka_Generi_II
{
    internal class NR1<T>
    {
         public isValidate<T> Validator { get;  }
       
        private  List<T> Masyvas { get; } 

        public NR1(List<T> items)
        {
            Masyvas = new List<T>(items);
            Validator=new isValidate<T>();
        }
        public void AddMasyvas(T masyvas)
        {
           
            if (Validator.isvalidate(masyvas))
                Masyvas.Add(masyvas);
        }
        public void PrintMasyvas()
        {
            foreach (T t in Masyvas)
            {
                Console.WriteLine(t);
            }
        }

        public T[] ConvertMasyvas()
        {
           T[] newmasyvas= Masyvas.ToArray();

            return newmasyvas;
        }

        public T FindIntenger(T items)
        {
         
            
                int suma = 0;
                foreach (T item in Masyvas)
                {
                    if (Equals(items, item))
                    {
                        suma++;
                    }
                }
                if (suma == 0)
                {
                    throw new InvalidOperationException("Nėra atitikmenų sąraše.");
                }
                else if (suma == 1)
                {
                    return items;
                }
                else
                    throw new InvalidOperationException("Atitikmenų daugiau nei vienas.");
            

        }
        public T FindIntengerDefault(T items)
        {
            int suma = 0;
            foreach (T item in Masyvas)
            {
                if (Equals(items, item))
                {
                    suma++;
                }
            }
            if (suma > 1)
            {
                throw new InvalidOperationException("Nėra atitikmenų sąraše.");
            }
            else if (suma == 1)
            {
                return items;
            }
            else
                return default;
        }

        public bool isValue(T items)
        {
            foreach (T item in Masyvas)
            {
                if (Equals(items, item))
                {
                    return true;
                }
            }
                return false;
        }


    }
}
