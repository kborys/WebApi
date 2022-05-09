using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class BookEntity
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        public bool IsRead { get; set; }
        public List<Author> Authors { get; set; }
    }
}
