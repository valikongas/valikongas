namespace _2_lygis_1_pamoka_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Person person1 = new Person(1.82);
            person1.Name = "Gedas";
            person1.Age = 30;

            Person person2 = new Person();
            person2.Name = "Tomas";
            person2.Age = 35;

            Person person3 = new Person("Vaida",40,1.62);

            Person  person4= new Person();
            Adress adress1 = new Adress();
            adress1.City = "Vilnius";
            adress1.Street = "ukmerges g.";
            adress1.HouseNo = 42;
            person1.PersonAdress = adress1;
            Adress adress2 =new Adress("Kaunas", "Savanoriu g.", 50);
            person2.PersonAdress = adress2;

            Console.WriteLine(person1.Name+" "+person1.Age+" ugis "+person1.Height+" " + person1.PersonAdress.City+", "+person1.PersonAdress.Street+", "+person1.PersonAdress.HouseNo);
            Console.WriteLine(person2.Name+" "+person2.Age+" ugis "+person2.Height);
            Console.WriteLine(person3.Name+" "+person3.Age+" ugis "+person3.Height);
            Console.WriteLine(person4.Name+" "+person4.Age+" ugis "+person4.Height);

            School school1 = new School("Vienuolio mokykla", 50);
            School school2 = new School("Staneviciaus mokykla");
            school1.City = "Vilniuje";
            school2.City = "Fabijoniskes";
            school2.MokiniuSkaicius = 30;
            Console.WriteLine(school1.Name + " yra " + school1.City + " mokinius skaicius " + school1.MokiniuSkaicius);
            Console.WriteLine(school2.Name + " yra " + school2.City + " mokinius skaicius " + school2.MokiniuSkaicius);

            //book klase
             List<Book> books = new List<Book>();
            Book book1 = new Book("Altoriu sesely", "Putinas", 2005, "Lietuva");
            
            Book book2 = new Book("Grafas Motekristas", "Diuma", 1915, "Prancuzija");
            Book book3 = new Book("Trys muskietininkai", "Diuma", 1925, "Italija");
            Book book4 = new Book("Anykciu silelis", "Baranauskas", 1955, "Lietuva");
            books.Add(book1);
            books.Add(book2);
            books.Add(book3);
            books.Add(book4);
            List<Book> filterBooks=BookFilter(books, "Diuma");
            foreach(Book book in filterBooks)
            Console.WriteLine(book.Author+" "+book.Title+" "+book.Year+" "+book.Country);
            
        }
        public static List<Book> BookFilter(List<Book> books, string name)
        {
            List<Book> filterBooks = new List<Book>();
            foreach (Book book in books)
            {
                if (book.Author == name)
                    filterBooks.Add(book);
            }


            return filterBooks;
        }

    }
}
