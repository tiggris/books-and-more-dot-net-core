using BooksAndMore.Catalogue.Domain.Model.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksAndMore.Catalogue.Infrastructure.Data.Mapping
{
    public class BookInfoEntityConfiguration : IEntityTypeConfiguration<BookInfo>
    {
        public void Configure(EntityTypeBuilder<BookInfo> builder)
        {
            builder.ToTable("Books", "catalogue");
            builder.HasKey(bookInfo => bookInfo.Id);
            builder.HasOne<Book>().WithOne().HasForeignKey<Book>(book => book.Id);
            builder.HasQueryFilter(bookInfo => bookInfo.State == State.Active);

            BookEntityConfiguration.MapTitleProperty(builder);
            BookEntityConfiguration.MapIsbnProperty(builder);
            BookEntityConfiguration.MapStateProperty(builder);            
        }
    }
}
