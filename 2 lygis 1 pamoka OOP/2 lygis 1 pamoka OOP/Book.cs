using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygis_1_pamoka_OOP
{
    internal class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string Country  { get; set; }

        public Book(string title,  string author, int year, string country)
        {  Title = title; Author = author; Year = year; Country = country;  }
    }
}
