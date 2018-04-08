using BooksAndMore.Catalogue.Domain.Model.Books;
using BooksAndMore.Catalogue.Infrastructure.Data.Mapping.ValueGenerators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.Converters;
using System;

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
            builder.HasMany(book => book.Reviews).WithOne().IsRequired();
            builder.HasOne(book => book.Publisher).WithMany().IsRequired();
            //builder.HasQueryFilter(book => book.State == State.Active);
            builder.HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangedNotifications);
            builder.UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.HasDiscriminator(book => book.IsIllustrated)
                .HasValue<Book>(false)
                .HasValue<IllustratedBook>(true);

            MapTitleProperty(builder);
            MapIsbnProperty(builder);
            MapStateProperty(builder);

            builder.Property(book => book.AverageRating)
                .IsRequired()
                .HasColumnType("decimal(3,2)")
                .HasDefaultValue(0)
                .HasValueGenerator<AverageRatingValueGenerator>()
                .ValueGeneratedOnUpdate();
        }

        public static void MapTitleProperty(EntityTypeBuilder builder)
        {
            builder.Property("Title")
                .HasColumnName("Title")
                .IsRequired()
                .HasMaxLength(100);
        }

        public static void MapIsbnProperty(EntityTypeBuilder builder)
        {
            builder.Property("Isbn")
               .IsRequired()
               .HasMaxLength(13)
               .HasColumnName("ISBN")
               .UsePropertyAccessMode(PropertyAccessMode.Field);
        }

        public static void MapStateProperty(EntityTypeBuilder builder)
        {
            builder.Property("State")
                .HasColumnName("State")
                .HasConversion<string>()
                .HasColumnType("nvarchar(20)")
                .HasDefaultValueSql($"N'Active'");
        }        
    }
}
