using BooksAndMore.Catalogue.Domain.Model.Authors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksAndMore.Catalogue.Infrastructure.Data.Mapping
{
    public class AuthorEntityConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(author => author.FirstName)
                .IsRequired()
                .HasMaxLength(30);
            builder.Property(author => author.LastName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(author => author.FullName)
                .HasComputedColumnSql("[FirstName] + ' ' + [LastName]");
        }
    }
}
