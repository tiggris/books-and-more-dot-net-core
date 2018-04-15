using BooksAndMore.Catalogue.Domain.Model.Authors;
using BooksAndMore.Catalogue.Domain.Model.Books;
using BooksAndMore.Catalogue.Domain.Model.Publishers;
using BooksAndMore.Catalogue.Infrastructure.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
            modelBuilder.HasDefaultSchema("catalogue");

            modelBuilder.ApplyConfiguration(new BookEntityConfiguration());
            //modelBuilder.ApplyConfiguration(new BookInfoEntityConfiguration());
            modelBuilder.ApplyConfiguration(new IllustratedBookEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorEntityConfiguration());
            modelBuilder.ApplyConfiguration(new IllustratorEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BookAuthorEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BookIllustratorEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PublisherEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewEntityConfiguration());

            SetRatedBookQuery(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void SetRatedBookQuery(ModelBuilder modelBuilder)
        {
            var sql = @"SELECT	book.Id,
		                        book.Title,
		                        AVG(CAST(review.Rating AS float)) AS AverageRating
                        FROM    catalogue.Books book INNER JOIN
	                            catalogue.Reviews review ON review.BookId = book.Id
                        GROUP BY book.Id, book.Title";

            modelBuilder.Query<RatedBook>()
                .ToQuery(() => Books.FromSql(sql).Select(query => new RatedBook
                {
                    Id = query.Id,
                    Title = query.Title,
                    AverageRating = query.AverageRating
                }));
        }
    }
}
