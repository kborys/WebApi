using System.ComponentModel.DataAnnotations;
using WebApi.Models.Books;

namespace WebApi.Models.Authors;

public class AuthorDto
{
    public int Id { get; set; }
    [Required]
    public string? FirstName { get; set; }
    [Required]
    public string? LastName { get; set; }
    public ICollection<Book> Books { get; set; }
}