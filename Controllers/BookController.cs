using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookContext _context;
        public BookController(BookContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Create), new {id = book.Id}, book);
        }



        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            var book = _context.Books.FirstOrDefault(p => p.Id == id);
            if (book is null) return NotFound();

            return book;
        }



        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAll()
        {
            var books = _context.Books;
            return books;
        }



        [HttpPut("{id}")]
        public IActionResult Update(int id, Book book)
        {
            if(id != book.Id) return BadRequest();

            var bookToUpdate = _context.Books.FirstOrDefault(p => p.Id == id);
            if(bookToUpdate is null) return NotFound();

            _context.Entry(bookToUpdate).CurrentValues.SetValues(book);
            _context.SaveChanges();

            return NoContent();
        }



        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _context.Books.FirstOrDefault(p => p.Id == id);
            if (book is null) return NotFound();

            _context.Books.Remove(book);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
