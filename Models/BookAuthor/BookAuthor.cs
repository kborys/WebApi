using WebApi.Models.Authors;
using WebApi.Models.Books;

namespace WebApi.Models.BookAuthor
{
    public class BookAuthor
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
