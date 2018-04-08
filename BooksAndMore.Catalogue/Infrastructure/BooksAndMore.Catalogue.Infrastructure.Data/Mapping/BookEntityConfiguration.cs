using BooksAndMore.Catalogue.Domain.Model.Books;
using BooksAndMore.Catalogue.Infrastructure.Data.Mapping.ValueGenerators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

            //builder.SeedData(
            //    new { Id = 1, Title = "Pan Tadeusz", Isbn = "9788388736919", PublisherId = 1, AverageRating = (decimal)0.0 },
            //    new { Id = 2, Title = "Dziady", Isbn = "9788373899285", PublisherId = 1, AverageRating = (decimal)0.0 },
            //    new { Id = 3, Title = "Sonety Krymskie", Isbn = "9781500143640", PublisherId = 2, AverageRating = (decimal)0.0 },
            //    new { Id = 4, Title = "Konrad Wallenrod", Isbn = "9781498181334", PublisherId = 3, AverageRating = (decimal)0.0 },
            //    new { Id = 5, Title = "Balladyna", Isbn = "9788377916605", PublisherId = 2, AverageRating = (decimal)0.0 },
            //    new { Id = 6, Title = "Anhelli", Isbn = "9780313208287", PublisherId = 1, AverageRating = (decimal)0.0 },
            //    new { Id = 7, Title = "Książka, której nigdy nie było", Isbn = "9876543210112", PublisherId = 3, AverageRating = (decimal)0.0 },
            //    new { Id = 8, Title = "Makbet", Isbn = "9788496509290", PublisherId = 2, AverageRating = (decimal)0.0 },
            //    new { Id = 9, Title = "Hamlet", Isbn = "9781348101864", PublisherId = 2, AverageRating = (decimal)0.0 },
            //    new { Id = 10, Title = "Romeo i Julia", Isbn = "9781387317844", PublisherId = 1, AverageRating = (decimal)0.0 },
            //    new { Id = 11, Title = "Ryszard III", Isbn = "9789510422311", PublisherId = 1, AverageRating = (decimal)0.0 },
            //    new { Id = 12, Title = "Wiele hałasu o nic", Isbn = "9781480297890", PublisherId = 3, AverageRating = (decimal)0.0 });
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
