﻿// <auto-generated />
using System;
using System.Collections.Generic;
using BooksAndMore.Catalogue.Domain.Model.Authors;
using BooksAndMore.Catalogue.Domain.Model.Books;
using BooksAndMore.Catalogue.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace BooksAndMore.Catalogue.Infrastructure.Data.Migrations.Migrations
{
    [DbContext(typeof(BooksCatalogueContext))]
    [Migration("20180420204214_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("catalogue")
                .HasAnnotation("ProductVersion", "2.1.0-preview2-30571")
                .HasAnnotation("Relational:Sequence:.BooksHiLoSequence", "'BooksHiLoSequence', '', '1', '100', '', '', 'Int32', 'False'")
                .HasAnnotation("Relational:Sequence:.EntityFrameworkHiLoSequence", "'EntityFrameworkHiLoSequence', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.PublisherIds", "'PublisherIds', '', '1', '1', '', '', 'Int32', 'False'")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BooksAndMore.Catalogue.Domain.Model.Authors.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "EntityFrameworkHiLoSequence")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<int>("AuthorType");

                    b.Property<string>("Bio");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("FullName")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasComputedColumnSql("[FirstName] + ' ' + [LastName]");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasDiscriminator<int>("AuthorType").HasValue(0);
                });

            modelBuilder.Entity("BooksAndMore.Catalogue.Domain.Model.Books.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "BooksHiLoSequence")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<decimal>("AverageRating")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("decimal(3,2)")
                        .HasDefaultValue(0m);

                    b.Property<string>("Description");

                    b.Property<bool>("IsIllustrated");

                    b.Property<string>("Isbn")
                        .IsRequired()
                        .HasColumnName("ISBN")
                        .HasMaxLength(13);

                    b.Property<int?>("PublisherId")
                        .IsRequired();

                    b.Property<string>("State")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20)
                        .HasDefaultValue("Active");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasAlternateKey("Isbn");

                    b.HasIndex("Isbn")
                        .IsUnique();

                    b.HasIndex("PublisherId");

                    b.ToTable("Books");

                    b.HasDiscriminator<bool>("IsIllustrated").HasValue(false);
                });

            modelBuilder.Entity("BooksAndMore.Catalogue.Domain.Model.Books.BookAuthor", b =>
                {
                    b.Property<int>("BookId");

                    b.Property<int>("AuthorId");

                    b.HasKey("BookId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.ToTable("BookAuthors","catalogue");
                });

            modelBuilder.Entity("BooksAndMore.Catalogue.Domain.Model.Books.BookIllustrator", b =>
                {
                    b.Property<int>("BookId");

                    b.Property<int>("IllustratorId");

                    b.HasKey("BookId", "IllustratorId");

                    b.HasIndex("IllustratorId");

                    b.ToTable("BookIllustrators","catalogue");
                });

            modelBuilder.Entity("BooksAndMore.Catalogue.Domain.Model.Books.Reviews.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookId");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GetUtcDate()");

                    b.Property<int>("Rating");

                    b.Property<string>("ReviewText");

                    b.Property<string>("ReviewerName")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("Reviews","catalogue");
                });

            modelBuilder.Entity("BooksAndMore.Catalogue.Domain.Model.Publishers.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEXT VALUE FOR catalogue.PublisherIds");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("BooksAndMore.Catalogue.Domain.Model.Authors.Illustrator", b =>
                {
                    b.HasBaseType("BooksAndMore.Catalogue.Domain.Model.Authors.Author");


                    b.ToTable("Illustrator");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("BooksAndMore.Catalogue.Domain.Model.Books.IllustratedBook", b =>
                {
                    b.HasBaseType("BooksAndMore.Catalogue.Domain.Model.Books.Book");


                    b.ToTable("IllustratedBook");

                    b.HasDiscriminator().HasValue(true);
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

            modelBuilder.Entity("BooksAndMore.Catalogue.Domain.Model.Books.BookIllustrator", b =>
                {
                    b.HasOne("BooksAndMore.Catalogue.Domain.Model.Books.IllustratedBook", "Book")
                        .WithMany("Illustrators")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BooksAndMore.Catalogue.Domain.Model.Authors.Illustrator", "Illustrator")
                        .WithMany()
                        .HasForeignKey("IllustratorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BooksAndMore.Catalogue.Domain.Model.Books.Reviews.Review", b =>
                {
                    b.HasOne("BooksAndMore.Catalogue.Domain.Model.Books.Book")
                        .WithMany("Reviews")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BooksAndMore.Catalogue.Domain.Model.Publishers.Publisher", b =>
                {
                    b.OwnsOne("BooksAndMore.Catalogue.Domain.Model.Publishers.Address", "Address", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd();

                            b1.Property<string>("Apartment");

                            b1.Property<string>("Building");

                            b1.Property<string>("City");

                            b1.Property<string>("Country");

                            b1.Property<string>("Street");

                            b1.Property<string>("ZipCode");

                            b1.ToTable("Publishers","catalogue");

                            b1.HasOne("BooksAndMore.Catalogue.Domain.Model.Publishers.Publisher")
                                .WithOne("Address")
                                .HasForeignKey("BooksAndMore.Catalogue.Domain.Model.Publishers.Address", "Id")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
