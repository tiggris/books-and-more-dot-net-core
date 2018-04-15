using BooksAndMore.Catalogue.Domain.Model.Authors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksAndMore.Catalogue.Infrastructure.Data.Mapping
{
    public class AuthorEntityConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasDiscriminator(author => author.AuthorType)
                .HasValue<Author>(AuthorType.Author)
                .HasValue<Illustrator>(AuthorType.Illustrator);
            
            builder.Property(author => author.FirstName)
                .IsRequired()
                .HasMaxLength(30);
            builder.Property(author => author.LastName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(author => author.FullName)
                .HasComputedColumnSql("[FirstName] + ' ' + [LastName]");

            builder.HasData(
                new { Id = 1, FirstName = "Adam", LastName = "Mickiewicz", AuthorType = AuthorType.Author },
                new { Id = 2, FirstName = "Juliusz", LastName = "Słowacki", AuthorType = AuthorType.Author },
                new { Id = 3, FirstName = "William", LastName = "Shakespeare", AuthorType = AuthorType.Author },
                new { Id = 4, FirstName = "H.P", LastName = "Lovecraft", AuthorType = AuthorType.Author });
        }        
    }
}
