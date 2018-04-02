using BooksAndMore.Catalogue.Domain.Model.Publishers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksAndMore.Catalogue.Infrastructure.Data.Mapping
{
    public class PublisherEntityConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.Property(publisher => publisher.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.OwnsOne(publisher => publisher.Address);
        }
    }
}
