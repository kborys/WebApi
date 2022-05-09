using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.Models.Authors;
using WebApi.Models.BookAuthor;
using WebApi.Models.Books;

namespace WebApi.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            // in-memory database for simplicity in development process
            // optionsBuilder.UseInMemoryDatabase("LibraryDb");

            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed the database on model creating
            //{
            //    modelBuilder.Entity<Author>().HasData(
            //        new Author { Id = 1, FirstName = "Konrad", LastName = "Borys" });

            //    modelBuilder.Entity<Book>().HasData(
            //        new Book { Id = 1, Title = "How to WebAPI", IsRead = false },
            //        new Book { Id = 2, Title = "How to C#", IsRead = true },
            //        new Book { Id = 3, Title = "How to SQL", IsRead = true });
            //}

            modelBuilder.Entity<BookAuthor>()
                .HasKey(ba => new {ba.BookId, ba.AuthorId});

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(ba => ba.BookId);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Author)
                .WithMany(a => a.BookAuthors)
                .HasForeignKey(ba => ba.AuthorId);
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthor> BookAuthor { get; set; }
    }
}
