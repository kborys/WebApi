using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using WebApi.Helpers;
using WebApi.Models;
using WebApi.Models.Books;

namespace WebApi.Services
{
    public interface IBookService
    {
        void Create(BookDto bookDto);
        BookDto GetById(int id);
        IEnumerable<BookDto> GetAll();
        void Update(int bookId, BookDto bookDto);
        void Delete(int bookId);
    }
    public class BookService : IBookService
    {
        private readonly DataContext _context;
        private readonly IBookMapper _mapper;
        public BookService(DataContext context, IBookMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public void Create(BookDto bookDto)
        {
            _context.Add(_mapper.MapToEntity(bookDto));
            _context.SaveChanges();
        }

        public BookDto GetById(int id)
        {
            var book = _context.Books.FirstOrDefault(p => p.Id == id);

            return _mapper.MapToDto(book);
        }

        public IEnumerable<BookDto> GetAll()
        {
            return _context.Books.Select(x => _mapper.MapToDto(x));
        }

        public void Update(int id, BookDto bookDto)
        {
            var bookToUpdate = _context.Books.FirstOrDefault(p => p.Id == id);
            _context.Entry(bookToUpdate).CurrentValues.SetValues(bookDto);

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = _context.Books.FirstOrDefault(p => p.Id == id);

            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}
