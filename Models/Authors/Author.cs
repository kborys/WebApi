using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Authors;

public class Author
{
    [Key]
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public ICollection<BookAuthor.BookAuthor> BookAuthors { get; set; }

}