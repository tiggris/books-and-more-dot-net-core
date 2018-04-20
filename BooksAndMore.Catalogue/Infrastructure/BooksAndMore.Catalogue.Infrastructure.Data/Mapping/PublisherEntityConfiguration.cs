using BooksAndMore.Catalogue.Domain.Model.Publishers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksAndMore.Catalogue.Infrastructure.Data.Mapping
{
    public class PublisherEntityConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            // Primary key with identity generated from sequence
            builder.Property(publisher => publisher.Id)
                .HasDefaultValueSql("NEXT VALUE FOR catalogue.PublisherIds");

            builder.Property(publisher => publisher.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Complex type configuration
            builder.OwnsOne(publisher => publisher.Address, (ownedPropertyBuilder) =>
            {
                ownedPropertyBuilder.Property<int>("Id");
                ownedPropertyBuilder.HasPrincipalKey("Id");

                 //Data seeding
                //ownedPropertyBuilder.HasData(
                //    new { Id = 1 },
                //    new { Id = 2 },
                //    new { Id = 3 });
            });

            // Data seeding
            //builder.HasData(
            //    new { Id = 1, Name = "Wydawnictwo Rebis" },
            //    new { Id = 2, Name = "Czarna Owca" },
            //    new { Id = 3, Name = "Wydawnictwo Znak" });
        }
    }
}
