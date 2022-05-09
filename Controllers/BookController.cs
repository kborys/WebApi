using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers;
using WebApi.Models;
using WebApi.Models.Books;
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
        public IActionResult Create(BookDto bookDto)
        {
            _bookService.Create(bookDto);

            return CreatedAtAction(nameof(Create), new {id = bookDto.Id}, bookDto);
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
        public IActionResult Update(int id, BookDto bookDto)
        {
            if(id != bookDto.Id) return BadRequest();

            var bookToUpdate = _bookService.GetById(id);
            if(bookToUpdate is null) return NotFound();

            _bookService.Update(id, bookDto);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _bookService.GetById(id);
            if (book is null) return NotFound();

            _bookService.Delete(id);

            return NoContent();
        }
    }
}
