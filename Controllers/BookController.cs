using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly LibraryContext _context;
        public BookController(LibraryContext context)
        {
            _context = context;
        }


        [HttpPost]
        public IActionResult Create(Book book)
        {
            _context.AddBook(book);

            return CreatedAtAction(nameof(Create), new {id = book.Id}, book);
        }


        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            var book = _context.GetBook(id);
            if (book is null) return NotFound();

            return book;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAll()
        {
            var books = _context.GetAllBooks();
            return books;
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, Book book)
        {
            if(id != book.Id) return BadRequest();

            var bookToUpdate = _context.GetBook(id);
            if(bookToUpdate is null) return NotFound();

            _context.UpdateBook(bookToUpdate, book);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _context.GetBook(id);
            if (book is null) return NotFound();

            _context.DeleteBook(book);

            return NoContent();
        }

    }
}
