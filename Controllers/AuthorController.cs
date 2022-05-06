using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly LibraryContext _context;
        public AuthorController(LibraryContext context)
        {
            _context = context;
        }


        [HttpPost]
        public IActionResult Create(Author author)
        {
            _context.AddAuthor(author);

            return CreatedAtAction(nameof(Create), new {id = author.Id}, author);
        }


        [HttpGet("{id}")]
        public ActionResult<Author> Get(int id)
        {
            var author = _context.GetAuthor(id);

            if(author is null) return NotFound();

            return author;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Author>> GetAll()
        {
            return _context.GetAllAuthors();
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, Author author)
        {
            if (id != author.Id) return BadRequest();

            var authorToUpdate = _context.GetAuthor(id);

            if (authorToUpdate is null) return NotFound();

            _context.UpdateAuthor(authorToUpdate, author);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var author = _context.GetAuthor(id);

            if (author is null) return NotFound();

            _context.DeleteAuthor(author);
            return NoContent();
        }
    }
}
