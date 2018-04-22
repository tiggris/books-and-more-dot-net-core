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
            builder.ToTable("Books"/*, "catalogue"*/);

            // Primary key with HiLo identity generation
            builder.HasKey(book => book.Id);
            builder.Property(book => book.Id).ForSqlServerUseSequenceHiLo("BooksHiLoSequence");

            // Alternate key is not the same as Unique Index
            builder.HasAlternateKey(book => book.Isbn);
            builder.HasIndex(book => book.Isbn).IsUnique();

            // One-to-one and One-to-many relationships
            builder.HasOne(book => book.Publisher).WithMany().IsRequired();
            builder.HasMany(book => book.BookAuthors).WithOne(bookAuthor => bookAuthor.Book);
            builder.HasMany(book => book.Reviews).WithOne().IsRequired();

            // Query filter
            builder.HasQueryFilter(book => book.State == State.Active);

            // Change tracking strategy
            //builder.HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangedNotifications);
            builder.UsePropertyAccessMode(PropertyAccessMode.Property);

            // Table per hierarchy inheritance
            builder.HasDiscriminator(book => book.IsIllustrated)
                .HasValue<Book>(false)
                .HasValue<IllustratedBook>(true);

            // Property with max length
            builder.Property("Title")
                .IsRequired()
                .HasMaxLength(100);

            // Property with field access mode 
            builder.Property("Isbn")
                .IsRequired()
                .HasMaxLength(13)
                .HasColumnName("ISBN")
                .UsePropertyAccessMode(PropertyAccessMode.Field);

            // Enum property mapped to string value with default value
            builder.Property("State")
                .IsRequired()
                .HasMaxLength(20)
                .HasConversion<string>()
                .HasDefaultValue(State.Active);

            // Property with specified column type and value generator
            builder.Property(book => book.AverageRating)
                .IsRequired()
                .HasColumnType("decimal(3,2)")
                .HasDefaultValue(0)
                .HasValueGenerator<AverageRatingValueGenerator>()
                .ValueGeneratedOnUpdate();

            // Data seeding
            //var currentDateTime = DateTimeProvider.CurrentDateTime;
            //builder.HasData(
            //    new { Id = 1, Title = "Pan Tadeusz", Isbn = "9788388736919", PublisherId = 1, State = State.Active, CreateDateTime = currentDateTime, LastUpdateDateTime = currentDateTime },
            //    new { Id = 2, Title = "Dziady", Isbn = "9788373899285", PublisherId = 1, State = State.Active, CreateDateTime = currentDateTime, LastUpdateDateTime = currentDateTime },
            //    new { Id = 3, Title = "Sonety Krymskie", Isbn = "9781500143640", PublisherId = 2, State = State.Active, CreateDateTime = currentDateTime, LastUpdateDateTime = currentDateTime },
            //    new { Id = 4, Title = "Konrad Wallenrod", Isbn = "9781498181334", PublisherId = 3, State = State.Active, CreateDateTime = currentDateTime, LastUpdateDateTime = currentDateTime },
            //    new { Id = 5, Title = "Balladyna", Isbn = "9788377916605", PublisherId = 2, State = State.Active, CreateDateTime = currentDateTime, LastUpdateDateTime = currentDateTime },
            //    new { Id = 6, Title = "Anhelli", Isbn = "9780313208287", PublisherId = 1, State = State.Active, CreateDateTime = currentDateTime, LastUpdateDateTime = currentDateTime },
            //    new { Id = 7, Title = "Książka, której nigdy nie było", Isbn = "9876543210112", PublisherId = 3, State = State.Active, CreateDateTime = currentDateTime, LastUpdateDateTime = currentDateTime },
            //    new { Id = 8, Title = "Makbet", Isbn = "9788496509290", PublisherId = 2, State = State.Active, CreateDateTime = currentDateTime, LastUpdateDateTime = currentDateTime },
            //    new { Id = 9, Title = "Hamlet", Isbn = "9781348101864", PublisherId = 2, State = State.Active, CreateDateTime = currentDateTime, LastUpdateDateTime = currentDateTime },
            //    new { Id = 10, Title = "Romeo i Julia", Isbn = "9781387317844", PublisherId = 1, State = State.Active, CreateDateTime = currentDateTime, LastUpdateDateTime = currentDateTime },
            //    new { Id = 11, Title = "Ryszard III", Isbn = "9789510422311", PublisherId = 1, State = State.Active, CreateDateTime = currentDateTime, LastUpdateDateTime = currentDateTime },
            //    new { Id = 12, Title = "Wiele hałasu o nic", Isbn = "9781480297890", PublisherId = 3, State = State.Active, CreateDateTime = currentDateTime, LastUpdateDateTime = currentDateTime });
        }
    }
}
