using BooksAndMore.Catalogue.Domain.Common;
using BooksAndMore.Catalogue.Domain.Model.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BooksAndMore.Catalogue.Infrastructure.Data.Mapping
{
    public class IllustratedBookEntityConfiguration : IEntityTypeConfiguration<IllustratedBook>
    {
        public void Configure(EntityTypeBuilder<IllustratedBook> builder)
        {
            // Derived type from Book
            builder.HasBaseType<Book>();

            // Data seeding
            var date = new DateTime(2018, 5, 1);
            builder.HasData(
                new { Id = 13, Title = "Mały Książę", Isbn = "9788995317471", PublisherId = 3, IsIllustrated = true, State = State.Active, CreateDateTime = date, LastUpdateDateTime = date },
                new { Id = 14, Title = "Kubuś Puchatek", Isbn = "9782230001040", PublisherId = 1, IsIllustrated = true, State = State.Active, CreateDateTime = date, LastUpdateDateTime = date });
        }
    }
}
