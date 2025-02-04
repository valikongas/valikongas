
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace DB_4_pamoka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //    using EF_Core_App;
            using var dbContext = new BookContext();
             
            var page1 = new Page(1, "same page text");
            dbContext.Pages.Add(page1);
            page1 = new Page(1, "same page text");
            dbContext.Pages.Add(page1);
            dbContext.Pages.Remove(page1);
            var result = dbContext.Pages.Where(x => x.Number == 1);
            foreach (var page in result)
            {
                dbContext.Pages.Remove(page);
            };
            dbContext.SaveChanges();
            
            
            //var book = new Book("Amazing book");

            //for (int i = 0; i < 599; i++)
            //{
            //    book.Pages.Add(new Page(i, $" Content {i * i}"));
            //}
            //dbContext.Books.Add(book);
            //dbContext.SaveChanges();



            //var book = dbContext.Books.Where(x=>x.Id==new Guid(" ")).Include(x=>x.Pages).ToList();
          

        }
    }
}
