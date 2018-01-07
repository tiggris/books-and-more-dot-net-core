﻿using BooksAndMore.Catalogue.Domain.Model.Authors;
using BooksAndMore.Catalogue.Domain.Model.Books;
using BooksAndMore.Catalogue.Domain.Model.Publishers;
using Microsoft.EntityFrameworkCore;

namespace BooksAndMore.Catalogue.Infrastructure.Data
{
    public class BooksCatalogueContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        public BooksCatalogueContext(DbContextOptions options) :
            base(options)
        {

        }
    }
}