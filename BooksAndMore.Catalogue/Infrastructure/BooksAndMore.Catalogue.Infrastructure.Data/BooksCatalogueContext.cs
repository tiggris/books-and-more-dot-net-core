using BooksAndMore.Catalogue.Domain.Model.Authors;
using BooksAndMore.Catalogue.Domain.Model.Books;
using BooksAndMore.Catalogue.Domain.Model.Publishers;
using BooksAndMore.Catalogue.Infrastructure.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace BooksAndMore.Catalogue.Infrastructure.Data
{
    public class BooksCatalogueContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        public BooksCatalogueContext(DbContextOptions options) :
            base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.ApplyConfiguration(new BookEntityConfiguration());

            modelBuilder.Entity<Publisher>(builder =>
            {
                builder.OwnsOne(publisher => publisher.Address);
            });

            modelBuilder.Entity<BookAuthor>()
                .HasKey(bookAuthor => new { bookAuthor.BookId, bookAuthor.AuthorId });

            base.OnModelCreating(modelBuilder);
        }        
    }
}
