using BooksAndMore.Catalogue.Domain.Model.Authors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksAndMore.Catalogue.Infrastructure.Data.Mapping
{
    public class IllustratorEntityConfiguration : IEntityTypeConfiguration<Illustrator>
    {
        public void Configure(EntityTypeBuilder<Illustrator> builder)
        {
            // Derived type from Author
            builder.HasBaseType<Author>();

            // Data seeding
            builder.HasData(
                new { Id = 7, FirstName = "Antoine", LastName = "de Saint-Exupéry", AuthorType = AuthorType.Illustrator },
                new { Id = 8, FirstName = "Ernest Howard", LastName = "Shepard", AuthorType = AuthorType.Illustrator });
        }
    }
}
