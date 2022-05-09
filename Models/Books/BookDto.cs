using System.ComponentModel.DataAnnotations;
using WebApi.Models.Authors;

namespace WebApi.Models.Books
{
    public class BookDto
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public bool IsRead { get; set; }
        [Required]
        public ICollection<Author> Authors { get; set; }
    }
}
