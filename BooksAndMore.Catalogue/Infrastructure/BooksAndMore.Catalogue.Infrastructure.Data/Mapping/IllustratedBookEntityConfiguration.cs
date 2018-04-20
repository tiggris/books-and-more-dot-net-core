using BooksAndMore.Catalogue.Domain.Model.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksAndMore.Catalogue.Infrastructure.Data.Mapping
{
    public class IllustratedBookEntityConfiguration : IEntityTypeConfiguration<IllustratedBook>
    {
        public void Configure(EntityTypeBuilder<IllustratedBook> builder)
        {
            // Derived type from Book
            builder.HasBaseType<Book>();

            // Data seeding
            //builder.HasData(
            //    new { Id = 13, Title = "Mały Książę", Isbn = "9788995317471", PublisherId = 3, State = State.Active, IsIllustrated = true },
            //    new { Id = 14, Title = "Kubuś Puchatek", Isbn = "9782230001040", PublisherId = 1, State = State.Active, IsIllustrated = true });
        }
    }
}
