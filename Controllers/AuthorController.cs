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
        private readonly AuthorContext _context;

        public AuthorController(AuthorContext context)
        {
            _context = context;
        }



        [HttpPost]
        public IActionResult Create(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Create), new {id = author.Id}, author);
        }

        [HttpGet("{id}")]
        public ActionResult<Author> Get(int id)
        {
            var author = _context.Authors.FirstOrDefault(author => author.Id == id);

            if (author == null)
                return NotFound();

            return author;
        }



        [HttpGet]
        public ActionResult<IEnumerable<Author>> GetAll()
        {
            var authors = _context.Authors;

            if (authors == null)
                return NotFound();

            return authors;
        }



        [HttpPut("{id}")]
        public IActionResult Update(int id, Author author)
        {
            if (id != author.Id)
                return BadRequest();

            var authorToUpdate = _context.Authors.FirstOrDefault(p => p.Id == id);
            if (authorToUpdate is null)
                return NotFound();

            _context.Entry(authorToUpdate).CurrentValues.SetValues(author);
            _context.SaveChanges();

            return NoContent();
        }



        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var author = _context.Authors.FirstOrDefault(p => p.Id == id);

            if (author == null) 
                return NotFound();

            _context.Authors.Remove(author);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
