using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Helpers
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            // in-memory database for simplicity in development process
            optionsBuilder.UseInMemoryDatabase("LibraryDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed the database on model creating
            {
                modelBuilder.Entity<Author>().HasData(
                    new Author { Id = 1, FirstName = "Konrad", LastName = "Borys" });

                modelBuilder.Entity<Book>().HasData(
                    new Book { Id = 1, AuthorId = 1, Title = "How to WebAPI", IsRead = false },
                    new Book { Id = 2, AuthorId = 1, Title = "How to C#", IsRead = true },
                    new Book { Id = 3, AuthorId = 1, Title = "How to SQL", IsRead = true });
            }
        }

        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<Book> Books { get; set; } = null!;
    }
}
