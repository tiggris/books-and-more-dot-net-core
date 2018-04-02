using BooksAndMore.Catalogue.Domain.Model.Books.Reviews;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksAndMore.Catalogue.Infrastructure.Data.Mapping
{
    public class ReviewEntityConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.Property(review => review.Rating)
                .IsRequired();
            builder.Property(review => review.ReviewerName)
                .HasMaxLength(50);
            builder.Property(review => review.ReviewText)
                .HasField("_reviewEncodedText")
                .UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(review => review.CreateDate)
                .HasDefaultValueSql("GetUtcDate()");
        }
    }
}
