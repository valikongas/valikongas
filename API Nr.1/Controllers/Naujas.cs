using API_Nr._1.Kodas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Nr._1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Naujas : ControllerBase
    {
        public static List<Book> _books = [];
        
        

        [HttpPost("assBook")]
        public ActionResult AddBook(Book name)
        {
            Book book1 = new Book(1, "Tostojus", "Karas");
            _books.Add(name);
            _books.Add(book1);
            return Ok();
        }

        [HttpGet]
        public ActionResult GetBook()
        {
            return Ok(_books);
        }

        [HttpGet("{title}")]

        public ActionResult<Book> GetByTitle(int title)
        {
            var book = _books.FirstOrDefault(x => x.Id == title);
            return Ok(book);
        }

        [HttpDelete("delete")]
        public ActionResult DeleteBook(int id)
        {
            var book = _books.FirstOrDefault(x => x.Id == id);
            _books.Remove(book);
            return Ok();
        }
    }
}
