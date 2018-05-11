using BooksAndMore.Catalogue.Domain.Model.Authors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BooksAndMore.Catalogue.Infrastructure.Data.Mapping
{
    public class AuthorDetailEntityConfiguration : IEntityTypeConfiguration<AuthorDetail>
    {
        public void Configure(EntityTypeBuilder<AuthorDetail> builder)
        {            
            builder.ToTable("Authors");

            builder.HasKey(authorDetail => authorDetail.Id);

            builder.Property(authorDetail => authorDetail.Id)
                .ForSqlServerUseSequenceHiLo("AuthorsHiLoSequence");

            builder.HasOne(authorDetail => authorDetail.Author)
                .WithOne(author => author.AuthorDetail)
                .HasForeignKey<Author>(author => author.Id);

            // Data seeding
            builder.HasData(
                new { Id = 1, Bio = "Adam Bernard Mickiewicz herbu Poraj – polski poeta, działacz polityczny, publicysta, tłumacz, filozof, działacz religijny, mistyk, organizator i dowódca wojskowy, nauczyciel akademicki.", BirthDate = new DateTime(1798, 12, 24) }
            );
        }        
    }
}
