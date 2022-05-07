using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }


        [HttpPost]
        public IActionResult Create(Book book)
        {
            _bookService.Create(book);

            return CreatedAtAction(nameof(Create), new {id = book.Id}, book);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var book = _bookService.GetById(id);
            if (book is null) return NotFound();

            return Ok(book);
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var books = _bookService.GetAll();
            return Ok(books);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, Book book)
        {
            if(id != book.Id) return BadRequest();

            var bookToUpdate = _bookService.GetById(id);
            if(bookToUpdate is null) return NotFound();

            _bookService.Update(bookToUpdate, book);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _bookService.GetById(id);
            if (book is null) return NotFound();

            _bookService.Delete(book);

            return NoContent();
        }
    }
}
