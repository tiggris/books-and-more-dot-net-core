using BooksAndMore.Catalogue.Domain.Model.Books.Reviews;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BooksAndMore.Catalogue.Infrastructure.Data.Mapping
{
    public class ReviewEntityConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Reviews", "catalogue");
            builder.Property(review => review.Rating)
                .IsRequired();
            builder.Property(review => review.ReviewerName)
                .HasMaxLength(50);

            // Field mapping
            builder.Property(review => review.ReviewText)
                .HasField("_reviewEncodedText")
                .UsePropertyAccessMode(PropertyAccessMode.Field);

            // Property with default value
            builder.Property(review => review.CreateDate)
                .HasDefaultValueSql("GetUtcDate()");

            // Data seeding
            var date = new DateTime(2018, 5, 1);
            builder.HasData(
                new { Id = 1, BookId = 1, Rating = 3, CreateDate = date },
                new { Id = 2, BookId = 1, Rating = 3, CreateDate = date },
                new { Id = 3, BookId = 1, Rating = 5, CreateDate = date },
                new { Id = 4, BookId = 1, Rating = 5, CreateDate = date },
                new { Id = 5, BookId = 2, Rating = 2, CreateDate = date },
                new { Id = 6, BookId = 2, Rating = 3, CreateDate = date },
                new { Id = 7, BookId = 3, Rating = 1, CreateDate = date },
                new { Id = 8, BookId = 4, Rating = 3, CreateDate = date },
                new { Id = 9, BookId = 4, Rating = 4, CreateDate = date },
                new { Id = 10, BookId = 5, Rating = 1, CreateDate = date },
                new { Id = 11, BookId = 5, Rating = 2, CreateDate = date },
                new { Id = 12, BookId = 5, Rating = 2, CreateDate = date },
                new { Id = 13, BookId = 5, Rating = 3, CreateDate = date },
                new { Id = 14, BookId = 5, Rating = 4, CreateDate = date },
                new { Id = 15, BookId = 5, Rating = 3, CreateDate = date },
                new { Id = 16, BookId = 5, Rating = 4, CreateDate = date },
                new { Id = 17, BookId = 5, Rating = 5, CreateDate = date },
                new { Id = 18, BookId = 6, Rating = 1, CreateDate = date },
                new { Id = 19, BookId = 6, Rating = 2, CreateDate = date },
                new { Id = 20, BookId = 6, Rating = 3, CreateDate = date },
                new { Id = 21, BookId = 6, Rating = 5, CreateDate = date },
                new { Id = 22, BookId = 7, Rating = 3, CreateDate = date },
                new { Id = 23, BookId = 7, Rating = 1, CreateDate = date },
                new { Id = 24, BookId = 7, Rating = 4, CreateDate = date },
                new { Id = 25, BookId = 8, Rating = 3, CreateDate = date },
                new { Id = 26, BookId = 9, Rating = 4, CreateDate = date },
                new { Id = 27, BookId = 10, Rating = 2, CreateDate = date },
                new { Id = 28, BookId = 10, Rating = 2, CreateDate = date },
                new { Id = 29, BookId = 10, Rating = 1, CreateDate = date },
                new { Id = 30, BookId = 10, Rating = 5, CreateDate = date },
                new { Id = 31, BookId = 11, Rating = 5, CreateDate = date },
                new { Id = 32, BookId = 11, Rating = 5, CreateDate = date });
        }
    }
}
