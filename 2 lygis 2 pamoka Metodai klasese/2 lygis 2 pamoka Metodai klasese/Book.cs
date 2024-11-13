using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygis_2_pamoka_Metodai_klasese
{
    internal class Book
    {
        public string Autor { get; set; }
        public string Name { get; set; }
        public int NumberPage { get; set; }

        public Book(string autor, string name, int numberpage)
        {
            Autor = autor;
            Name = name;
            NumberPage = numberpage;
        }
      


    }
}
