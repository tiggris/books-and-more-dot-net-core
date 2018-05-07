using BooksAndMore.Catalogue.Domain.Model.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksAndMore.Catalogue.Infrastructure.Data.Mapping
{
    public class BookIllustratorEntityConfiguration : IEntityTypeConfiguration<BookIllustrator>
    {
        public void Configure(EntityTypeBuilder<BookIllustrator> builder)
        {
            builder.ToTable("BookIllustrators", "catalogue");
            builder.HasKey(bookIllustrator => new { bookIllustrator.BookId, bookIllustrator.IllustratorId });

            // Data seeding
            builder.HasData(
                new { BookId = 13, IllustratorId = 7 },
                new { BookId = 14, IllustratorId = 8 });
        }
    }
}
