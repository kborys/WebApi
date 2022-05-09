using WebApi.Models;
using WebApi.Models.Books;

namespace WebApi.Helpers
{
    public interface IBookMapper
    {
        Book MapToEntity(BookDto dto);
        BookDto MapToDto(Book entity);
    }

    public class BookMapper : IBookMapper
    {
        public Book MapToEntity(BookDto dto)
        {
            return new Book()
            {
                Id = dto.Id,
                Title = dto.Title,
                IsRead = dto.IsRead,
                //Authors = dto.Authors
            };
        }

        public BookDto MapToDto(Book entity)
        {
            return new BookDto()
            {
                Id = entity.Id,
                Title = entity.Title,
                IsRead = entity.IsRead,
                //Authors = entity.Authors
            };
        }
    }
}
