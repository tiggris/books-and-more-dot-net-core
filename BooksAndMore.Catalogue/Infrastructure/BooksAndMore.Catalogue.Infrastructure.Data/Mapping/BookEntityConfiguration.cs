using BooksAndMore.Catalogue.Domain.Model.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.Converters;

namespace BooksAndMore.Catalogue.Infrastructure.Data.Mapping
{
    public class BookEntityConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books", "catalogue");
            builder.HasKey(book => book.Id);
            builder.HasAlternateKey(book => book.Isbn);
            builder.HasIndex(book => book.Isbn).IsUnique();
            builder.HasMany(book => book.BookAuthors).WithOne(bookAuthor => bookAuthor.Book);
            builder.HasOne(book => book.Publisher).WithMany().IsRequired();
            builder.HasQueryFilter(book => book.State == State.Active);
            builder.HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangedNotifications);
            builder.UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Property(book => book.Title)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(book => book.Isbn)
                .IsRequired()
                .HasMaxLength(13)
                .HasColumnName("ISBN")
                .UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(book => book.State)
                .HasConversion<string>()
                .HasDefaultValueSql($"'{State.Active.ToString()}'");
            builder.Property(book => book.AverageRating)
                .IsRequired()
                .HasColumnType("decimal(3,2)")
                .HasDefaultValue(0)
                .HasValueGenerator<AverageRatingValueGenerator>()
                .ValueGeneratedOnUpdate();   
        }
    }
}
