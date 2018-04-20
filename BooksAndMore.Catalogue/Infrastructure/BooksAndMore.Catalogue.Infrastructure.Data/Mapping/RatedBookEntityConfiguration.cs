using BooksAndMore.Catalogue.Domain.Model.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;

namespace BooksAndMore.Catalogue.Infrastructure.Data.Mapping
{
    public static class RatedBookEntityConfiguration
    {
        public static QueryTypeBuilder<RatedBook> RatedBookQuery(this ModelBuilder modelBuilder, DbSet<Book> dbSet)
        {
            var sql = @"SELECT	book.Id,
		                        book.Title,
		                        AVG(CAST(review.Rating AS float)) AS AverageRating
                        FROM    catalogue.Books book INNER JOIN
	                            catalogue.Reviews review ON review.BookId = book.Id
                        GROUP BY book.Id, book.Title";

            // Query type
            return modelBuilder.Query<RatedBook>()
                .ToQuery(() => dbSet.FromSql(sql).Select(query => new RatedBook
                {
                    Id = query.Id,
                    Title = query.Title,
                    AverageRating = query.AverageRating
                }));
        }
    }
}
