using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IEnumerable<Author> GetAuthors()
        {
            var authors = _context.Authors;
            return authors;
        }

        [HttpPost]
        public void PostAuthor(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        //[HttpPost]
        //public async Task<ActionResult<Author>> PostAuthor(Author author)
        //{
        //    _context.Authors.Add(author);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction(nameof(GetAuthors), new {id = author.Id}, author);
        //}
    }
}
