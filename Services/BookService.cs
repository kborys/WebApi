using Microsoft.EntityFrameworkCore;
using WebApi.Helpers;
using WebApi.Models;

namespace WebApi.Services
{
    public interface IBookService
    {
        void Create(Book book);
        Book GetById(int id);
        DbSet<Book> GetAll();
        void Update(Book bookToUpdate, Book book);
        void Delete(Book book);
    }
    public class BookService : IBookService
    {
        private readonly DataContext _context;
        public BookService(DataContext context)
        {
            _context = context;
        }


        public void Create(Book book)
        {
            _context.Add(book);
            _context.SaveChanges();
        }

        public Book GetById(int id)
        {
            var book = _context.Books.FirstOrDefault(p => p.Id == id);

            return book;
        }

        public DbSet<Book> GetAll()
        {
            return _context.Books;
        }

        public void Update(Book bookToUpdate, Book book)
        {
            _context.Entry(bookToUpdate).CurrentValues.SetValues(book);
            _context.SaveChanges();
        }

        public void Delete(Book book)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}
