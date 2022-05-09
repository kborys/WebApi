using WebApi.Models;

namespace WebApi.Helpers
{
    public interface IBookMapper
    {
        BookEntity MapToEntity(BookDto dto);
        BookDto MapToDto(BookEntity entity);
    }

    public class BookMapper : IBookMapper
    {
        public BookEntity MapToEntity(BookDto dto)
        {
            return new BookEntity()
            {
                BookId = dto.BookId,
                Title = dto.Title,
                IsRead = dto.IsRead,
                Authors = dto.Authors
            };
        }

        public BookDto MapToDto(BookEntity entity)
        {
            return new BookDto()
            {
                BookId = entity.BookId,
                Title = entity.Title,
                IsRead = entity.IsRead,
                Authors = entity.Authors
            };
        }
    }
}
