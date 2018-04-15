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

            builder.OwnsOne(publisher => publisher.Address, (ownedPropertyBuilder) =>
            {
                ownedPropertyBuilder.Property<int>("Id");
                ownedPropertyBuilder.HasPrincipalKey("Id");
                //ownedPropertyBuilder.HasData(
                //    new { Id = 1, Street = "street one" },
                //    new { Id = 2, Street = "street two" },
                //    new { Id = 3, Street = "street three" });
            });

            //builder.HasData(
            //    new { Id = 1, Name = "Wydawnictwo Rebis" },
            //    new { Id = 2, Name = "Czarna Owca" },
            //    new { Id = 3, Name = "Wydawnictwo Znak" });
        }
    }
}
