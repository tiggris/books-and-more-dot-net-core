using BooksAndMore.Catalogue.Domain.Common.Model;
using BooksAndMore.Catalogue.Domain.Model.Authors;
using BooksAndMore.Catalogue.Domain.Model.Books;
using BooksAndMore.Catalogue.Domain.Model.Publishers;
using BooksAndMore.Catalogue.Infrastructure.Data.Mapping;
using BooksAndMore.Catalogue.Infrastructure.Data.Mapping.ValueGenerators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;

namespace BooksAndMore.Catalogue.Infrastructure.Data
{
    public class BooksCatalogueContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbQuery<RatedBook> RatedBooks { get; set; }

        public int ReviewsCount(int bookId)
        {
            throw new Exception();
        }

        public BooksCatalogueContext(DbContextOptions options) :
            base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.ConfigureWarnings(config => 
                config.Log( CoreEventId.DetachedLazyLoadingWarning,
                            CoreEventId.LazyLoadOnDisposedContextWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Default schema for all tables
            modelBuilder.HasDefaultSchema("catalogue");

            // Sequence definition
            modelBuilder.HasSequence<int>("PublisherIds"/*, schema: "catalogue"*/)
                .StartsAt(100)
                .IncrementsBy(1);

            // HiLo sequence definition
            modelBuilder.HasSequence<int>("BooksHiLoSequence")
                .StartsAt(100)
                .IncrementsBy(100);

            // HiLo sequence definition
            modelBuilder.HasSequence<int>("AuthorsHiLoSequence")
                .StartsAt(100)
                .IncrementsBy(100);

            // Global owned type definition
            modelBuilder.Owned<Address>();

            // DB function
            modelBuilder.HasDbFunction(() => ReviewsCount(default(int)))
                .HasName("ReviewsCount")
                .HasSchema("catalogue");

            // Query type
            modelBuilder.RatedBookQuery(Books);

            // Entity configurations
            modelBuilder.ApplyConfiguration(new BookEntityConfiguration());
            modelBuilder.ApplyConfiguration(new IllustratedBookEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorEntityConfiguration());
            modelBuilder.ApplyConfiguration(new IllustratorEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BookAuthorEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BookIllustratorEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PublisherEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewEntityConfiguration());

            ConfigureShadowProperties(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureShadowProperties(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // Add CreatedAt/UpdatedAt properties to entities
                if (typeof(IAuditable).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .Property<DateTime>(AuditableProperties.CreatedAt)
                        .IsRequired()
                        .HasDefaultValueSql("GETUTCDATE()");
                    modelBuilder.Entity(entityType.ClrType)
                        .Property<DateTime>(AuditableProperties.UpdatedAt)
                        .IsRequired()
                        .HasDefaultValueSql("GETUTCDATE()")
                        .HasValueGenerator<CurrentDateTimeValueGenerator>()
                        .ValueGeneratedOnUpdate();
                }

                // Add RowVersion property to entities
                if (typeof(IVersioned).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType).Property<byte[]>("RowVersion").IsRowVersion();
                }
            }
        }
    }
}
