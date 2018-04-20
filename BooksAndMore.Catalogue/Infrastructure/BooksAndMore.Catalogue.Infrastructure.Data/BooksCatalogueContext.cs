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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Default schema for all tables
            modelBuilder.HasDefaultSchema("catalogue");

            // Sequence definition
            modelBuilder.HasSequence<int>("PublisherIds"/*, schema: "catalogue"*/)
                .StartsAt(1)
                .IncrementsBy(1);

            // HiLo sequence definition
            modelBuilder.HasSequence<int>("BooksHiLoSequence")
                .StartsAt(1)
                .IncrementsBy(100);

            // Global owned type definition
            modelBuilder.Owned<Address>();

            // DB function
            modelBuilder.HasDbFunction(() => UserDefinedFunctions.ReviewsCount(default(int)))
                .HasName("ReviewsCount")
                .HasSchema("catalogue");

            // Query type
            modelBuilder.RatedBookQuery(Books);

            // Entity configurations
            modelBuilder.ApplyConfiguration(new BookEntityConfiguration());
            modelBuilder.ApplyConfiguration(new IllustratedBookEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorEntityConfiguration());
            modelBuilder.ApplyConfiguration(new IllustratorEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BookAuthorEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BookIllustratorEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PublisherEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
