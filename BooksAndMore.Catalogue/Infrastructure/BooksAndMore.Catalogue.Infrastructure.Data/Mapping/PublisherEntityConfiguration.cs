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

            //builder.SeedData(
            //    new { Id = 1, Name = "Wydawnictwo Rebis" },
            //    new { Id = 2, Name = "Czarna Owca" },
            //    new { Id = 3, Name = "Wydawnictwo Znak" });

            builder.OwnsOne(publisher => publisher.Address);
                //.SeedData(
                //    new { PublisherId = 1 },
                //    new { PublisherId = 2 },
                //    new { PublisherId = 3 });
        }
    }
}
