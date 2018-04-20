using BooksAndMore.Catalogue.Domain.Model.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksAndMore.Catalogue.Infrastructure.Data.Mapping
{
    public class BookAuthorEntityConfiguration : IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            // Join table entity
            builder.ToTable("BookAuthors", "catalogue");

            // Composite primary key
            builder.HasKey(bookAuthor => new { bookAuthor.BookId, bookAuthor.AuthorId });

            // Data seeding - not working :(
            //builder.HasData(
            //    new { BookId = 1, AuthorId = 1 },
            //    new { BookId = 2, AuthorId = 1 },
            //    new { BookId = 3, AuthorId = 1 },
            //    new { BookId = 4, AuthorId = 1 },
            //    new { BookId = 5, AuthorId = 2 },
            //    new { BookId = 6, AuthorId = 2 },
            //    new { BookId = 7, AuthorId = 1 },
            //    new { BookId = 7, AuthorId = 2 },
            //    new { BookId = 8, AuthorId = 3 },
            //    new { BookId = 9, AuthorId = 3 },
            //    new { BookId = 10, AuthorId = 3 },
            //    new { BookId = 11, AuthorId = 3 },
            //    new { BookId = 12, AuthorId = 3 });
        }
    }
}
