using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed the database on model creating
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, FirstName = "Konrad", LastName = "Borys" }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, AuthorId = 1, Title = "How to WebAPI", IsRead = false },
                new Book { Id = 2, AuthorId = 1, Title = "How to C#", IsRead = true },
                new Book { Id = 3, AuthorId = 1, Title = "How to SQL", IsRead = true }
            );
        }

        private DbSet<Author> Authors { get; set; } = null!;
        private DbSet<Book> Books { get; set; } = null!;


        public void AddAuthor(Author author)
        {
            Authors.Add(author);
            SaveChanges();
        }

        public Author GetAuthor(int id)
        {
            var author = Authors.FirstOrDefault(p => p.Id == id);
            return author;
        }

        public DbSet<Author> GetAllAuthors()
        {
            return Authors;
        }

        public void UpdateAuthor(Author authorToUpdate, Author author)
        {
            Entry(authorToUpdate).CurrentValues.SetValues(author);
            SaveChanges();
        }

        public void DeleteAuthor(Author author)
        {
            Authors.Remove(author);
            SaveChanges();
        }


        public void AddBook(Book book)
        {
            Books.Add(book);
            SaveChanges();
        }

        public Book GetBook(int id)
        {
            var book = Books.FirstOrDefault(p => p.Id == id);
            return book;
        }

        public DbSet<Book> GetAllBooks()
        {
            return Books;
        }

        public void UpdateBook(Book bookToUpdate, Book book)
        {
            Entry(bookToUpdate).CurrentValues.SetValues(book);
            SaveChanges();
        }

        public void DeleteBook(Book book)
        {
            Books.Remove(book);
            SaveChanges();
        }
    }
}
