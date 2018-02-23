﻿// <auto-generated />
using BooksAndMore.Catalogue.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace BooksAndMore.Catalogue.Infrastructure.Data.Migrations
{
    [DbContext(typeof(BooksCatalogueContext))]
    partial class BooksCatalogueContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
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

                    b.Property<string>("Description");

                    b.Property<string>("Isbn");

                    b.Property<int?>("PublisherId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("PublisherId");

                    b.ToTable("Books");
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

                    b.Property<int>("Rating");

                    b.Property<DateTime>("CreateDate");

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

                    b.Property<string>("AddressApartment");

                    b.Property<string>("AddressBuilding");

                    b.Property<string>("AddressCity");

                    b.Property<string>("AddressCountry");

                    b.Property<string>("AddressStreet");

                    b.Property<string>("AddressZipCode");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("BooksAndMore.Catalogue.Domain.Model.Books.Book", b =>
                {
                    b.HasOne("BooksAndMore.Catalogue.Domain.Model.Publishers.Publisher", "Publisher")
                        .WithMany()
                        .HasForeignKey("PublisherId");
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
#pragma warning restore 612, 618
        }
    }
}