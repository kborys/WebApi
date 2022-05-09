using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Books
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsRead { get; set; }
        public ICollection<BookAuthor.BookAuthor> BookAuthors { get; set; }
    }
}
