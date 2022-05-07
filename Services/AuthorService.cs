using Microsoft.EntityFrameworkCore;
using WebApi.Helpers;
using WebApi.Models;

namespace WebApi.Services
{
    public interface IAuthorService
    {
        void Create(Author author);
        Author GetById(int id);
        DbSet<Author> GetAll();
        void Update(Author authorToUpdate, Author author);
        void Delete(Author author);
    }
    public class AuthorService : IAuthorService
    {
        private readonly DataContext _context;
        public AuthorService(DataContext context)
        {
            _context = context;
        }
        public void Create(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public Author GetById(int id)
        {
            var author = _context.Authors.FirstOrDefault(p => p.Id == id);

            return author;
        }

        public DbSet<Author> GetAll()
        {
            return _context.Authors;
        }

        public void Update(Author authorToUpdate, Author author)
        {
            _context.Entry(authorToUpdate).CurrentValues.SetValues(author);
            _context.SaveChanges();
        }

        public void Delete(Author author)
        {
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
}
