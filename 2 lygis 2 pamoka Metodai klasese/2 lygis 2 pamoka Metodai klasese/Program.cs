using System.Globalization;

namespace _2_lygis_2_pamoka_Metodai_klasese
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Number number = new Number();
            number.AddNumber(10);
            number.AddNumber(30);
            number.AddNumber(50);
            number.PrintNumbers();

            //rectangle

            var HeightandLenght1 = new Rectangle(2.0, 5.0);

            Console.WriteLine("Plotas yra: "+HeightandLenght1.Area());
            Console.WriteLine("Perimetras yra:" + HeightandLenght1.Perimeter());


            // Library

            Library library = new Library();
            Book book1 = new Book("Putinas", "Altoriu seseli", 150);
            Book book2 = new Book("Taranas", "Tarzanas", 30);
            Book book3 = new Book("Konondoilis", "Vatsonas", 100);
            Book book4 = new Book("Donelaitis", "Metai", 35);
            Book book5 = new Book("Baranauskas", "Silelis", 130);
            

            library.AddBook(book1);
            library.AddBook(book2);
            library.RemoveBook(book1);
            library.AddBook(book3);
            library.AddBook(book4);
            library.AddBook(book5);
            library.PrintBook();
            Console.WriteLine($"Antra knyga skaitysi {library.ReadTime(book2)} valandu");
            Console.WriteLine($"Pirma knyga skaitysi {library.ReadTime(book1)} valandu");
            Console.WriteLine($"Knyga kurios pavadinimas \"Metai\" skaitysi {library.ReadTimeByName("Metai")} valandu");

            foreach (Book book in library.books)
            {
                Console.WriteLine($"{book.Autor} {book.Name} {library.ReadTime(book)}");
            }
        }
    }
}
