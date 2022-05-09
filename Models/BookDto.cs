using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class BookDto
    {
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public bool IsRead { get; set; }
        [Required]
        public List<Author> Authors { get; set; }
    }
}
