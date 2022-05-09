using Microsoft.AspNetCore.Server.IIS.Core;
using WebApi.Helpers;
using WebApi.Models.BookAuthor;
using WebApi.Models.Books;

namespace WebApi.Services
{
    public interface IBookAuthorService
    {
        void AddBookAuthor(AddBookAuthorDto newBookAuthor);
    }
    public class BookAuthorService : IBookAuthorService
    {
        private readonly DataContext _context;

        public BookAuthorService(DataContext context)
        {
            _context = context;
        }
        public void AddBookAuthor(AddBookAuthorDto newBookAuthor)
        {
            try
            {
                Book book = _context.Books
                    .FirstOrDefault(b => b.Id == newBookAuthor.BookId);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
