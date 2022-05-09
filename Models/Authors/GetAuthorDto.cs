namespace WebApi.Models.Authors
{
    public class GetAuthorDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public ICollection<Author> Authors { get; set; }
    }
}
