using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Generic<T>
    {
        private T[] myArray {  get; set; }
        private int Index = 0;
        private int Size = 5;

        public Generic()
        {
            myArray = new T[Size];
        }
      
            
        public void AddItem(T item)
        {
            if (CheckIsFull())
            {
                myArray = IncreaseListSize();
            }
            if (item != null)
            {
                myArray[Index] = item;
                Index++;
            }
            else

            {
                throw new ArgumentException($"Nepavyko prideti {item}");
            }
        }

        private bool CheckIsFull()
        {
            return (Index == Size); 
        }
        private T[] IncreaseListSize ()
        {
            Size += (Size / 2);
            var newArray= new T[Size];
            myArray.CopyTo(newArray, 0);
            return newArray;

        }
        
        public List<T> GetArray1  ()
        {
           return myArray.ToList();
        }

        public void RemoveItem1(T item)
        {
           
            // 1 variantas
            int  indeksas = -1;
            for (int i = 0; i < Size; i++)
            {
                if (myArray[i].Equals(item))
                {
                    indeksas = i;
                    break;
                }
            }
          
           
            if( indeksas >= 0 )
            {
                for (int i = indeksas+1; i<Size; i++)
                {
                    myArray[i-1]=myArray[i];

                }
                Index--;
     

              
            }


            //// 2 variantas
            //    List<T> list = myArray.ToList();
            //if (list.Contains(item))
            //{
            //    list.Remove(item);
            //    myArray = list.ToArray();
            //    Index--;
            //}
  
        
        }


    }
}
