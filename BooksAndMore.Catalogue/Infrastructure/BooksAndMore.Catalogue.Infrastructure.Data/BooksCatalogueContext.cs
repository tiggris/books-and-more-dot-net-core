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
            modelBuilder.HasDefaultSchema("catalogue");

            modelBuilder.ApplyConfiguration(new BookEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BookInfoEntityConfiguration());
            modelBuilder.ApplyConfiguration(new IllustratedBookEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorEntityConfiguration());
            modelBuilder.ApplyConfiguration(new IllustratorEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BookAuthorEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BookIllustratorEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PublisherEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewEntityConfiguration());

            //modelBuilder.Entity<Publisher>(builder =>
            //{
            //    builder.Property(publisher => publisher.Name)
            //    .IsRequired()
            //    .HasMaxLength(100);
            //    builder.OwnsOne(publisher => publisher.Address);
            //});

            base.OnModelCreating(modelBuilder);
        }
    }
}
