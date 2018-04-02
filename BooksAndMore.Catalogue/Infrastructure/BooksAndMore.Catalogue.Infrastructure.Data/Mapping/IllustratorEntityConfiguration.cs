using BooksAndMore.Catalogue.Domain.Model.Authors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksAndMore.Catalogue.Infrastructure.Data.Mapping
{
    public class IllustratorEntityConfiguration : IEntityTypeConfiguration<Illustrator>
    {
        public void Configure(EntityTypeBuilder<Illustrator> builder)
        {
            builder.HasBaseType<Author>();
        }
    }
}
