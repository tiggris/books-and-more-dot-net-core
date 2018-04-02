﻿// <auto-generated />
using System;
using BooksAndMore.Catalogue.Domain.Model.Books;
using BooksAndMore.Catalogue.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace BooksAndMore.Catalogue.Infrastructure.Data.Migrations
{
    [DbContext(typeof(BooksCatalogueContext))]
    partial class BooksCatalogueContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-preview1-28290")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BooksAndMore.Catalogue.Domain.Model.Authors.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bio");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("BooksAndMore.Catalogue.Domain.Model.Books.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("AverageRating")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("decimal(3,2)")
                        .HasDefaultValue(0m);

                    b.Property<string>("Description");

                    b.Property<string>("Isbn")
                        .IsRequired()
                        .HasColumnName("ISBN")
                        .HasMaxLength(13)
                        .HasAnnotation("PropertyAccessMode", PropertyAccessMode.Field);

                    b.Property<int?>("PublisherId")
                        .IsRequired();

                    b.Property<int>("State")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("'Active'")
                        .HasConversion<string>();

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasAlternateKey("Isbn");

                    b.HasIndex("Isbn")
                        .IsUnique();

                    b.HasIndex("PublisherId");

                    b.ToTable("Books","catalogue");

                    b.HasAnnotation("PropertyAccessMode", PropertyAccessMode.Property);
                });

            modelBuilder.Entity("BooksAndMore.Catalogue.Domain.Model.Books.BookAuthor", b =>
                {
                    b.Property<int>("BookId");

                    b.Property<int>("AuthorId");

                    b.HasKey("BookId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.ToTable("BookAuthor");
                });

            modelBuilder.Entity("BooksAndMore.Catalogue.Domain.Model.Books.Reviews.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BookId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<int>("Rating");

                    b.Property<string>("ReviewText");

                    b.Property<string>("ReviewerName");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("BooksAndMore.Catalogue.Domain.Model.Publishers.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("BooksAndMore.Catalogue.Domain.Model.Books.Book", b =>
                {
                    b.HasOne("BooksAndMore.Catalogue.Domain.Model.Publishers.Publisher", "Publisher")
                        .WithMany()
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BooksAndMore.Catalogue.Domain.Model.Books.BookAuthor", b =>
                {
                    b.HasOne("BooksAndMore.Catalogue.Domain.Model.Authors.Author", "Author")
                        .WithMany("BookAuthors")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BooksAndMore.Catalogue.Domain.Model.Books.Book", "Book")
                        .WithMany("BookAuthors")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BooksAndMore.Catalogue.Domain.Model.Books.Reviews.Review", b =>
                {
                    b.HasOne("BooksAndMore.Catalogue.Domain.Model.Books.Book")
                        .WithMany("Reviews")
                        .HasForeignKey("BookId");
                });

            modelBuilder.Entity("BooksAndMore.Catalogue.Domain.Model.Publishers.Publisher", b =>
                {
                    b.OwnsOne("BooksAndMore.Catalogue.Domain.Model.Publishers.Address", "Address", b1 =>
                        {
                            b1.Property<int?>("PublisherId");

                            b1.Property<string>("Apartment");

                            b1.Property<string>("Building");

                            b1.Property<string>("City");

                            b1.Property<string>("Country");

                            b1.Property<string>("Street");

                            b1.Property<string>("ZipCode");

                            b1.ToTable("Publishers");

                            b1.HasOne("BooksAndMore.Catalogue.Domain.Model.Publishers.Publisher")
                                .WithOne("Address")
                                .HasForeignKey("BooksAndMore.Catalogue.Domain.Model.Publishers.Address", "PublisherId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
