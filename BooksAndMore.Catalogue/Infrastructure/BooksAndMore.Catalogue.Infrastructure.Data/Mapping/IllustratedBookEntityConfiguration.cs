using BooksAndMore.Catalogue.Domain.Model.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksAndMore.Catalogue.Infrastructure.Data.Mapping
{
    public class IllustratedBookEntityConfiguration : IEntityTypeConfiguration<IllustratedBook>
    {
        public void Configure(EntityTypeBuilder<IllustratedBook> builder)
        {
            builder.HasBaseType<Book>();
        }
    }
}
