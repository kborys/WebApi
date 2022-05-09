using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }


        [HttpPost]
        public IActionResult Create(Author author)
        {
            _authorService.Create(author);

            return CreatedAtAction(nameof(Create), new {id = author.AuthorId}, author);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var author = _authorService.GetById(id);

            if(author is null) return NotFound();

            return Ok(author);
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_authorService.GetAll());
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, Author author)
        {
            if (id != author.AuthorId) return BadRequest();

            var authorToUpdate = _authorService.GetById(id);

            if (authorToUpdate is null) return NotFound();

            _authorService.Update(authorToUpdate, author);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var author = _authorService.GetById(id);

            if (author is null) return NotFound();

            _authorService.Delete(author);
            return NoContent();
        }
    }
}
