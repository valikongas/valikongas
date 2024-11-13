using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygis_2_pamoka_Metodai_klasese
{
    internal class Library
    {
        public List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            books.Remove(book);
        }

        public void PrintBook()
        {
            foreach (Book book in books)
            {
                Console.WriteLine(book.Autor + " " + book.Name);
            }
        }

        public double ReadTime(Book book)
        {
            double time = book.NumberPage/50.0;
            return time;     
        }

        public double ReadTimeByName(string name)
        {
            double time = 0.0;
            foreach (Book book in books)
            {
                if (book.Name == name)
                {
                    time = book.NumberPage / 50.0;
                }
            }
            return time;
        }
    }
}
