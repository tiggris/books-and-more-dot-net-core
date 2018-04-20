using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksAndMore.Catalogue.Infrastructure.Data.Migrations.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "catalogue");

            migrationBuilder.CreateSequence<int>(
                name: "BooksHiLoSequence",
                schema: "catalogue",
                incrementBy: 100);

            migrationBuilder.CreateSequence(
                name: "EntityFrameworkHiLoSequence",
                schema: "catalogue",
                incrementBy: 10);

            migrationBuilder.CreateSequence<int>(
                name: "PublisherIds",
                schema: "catalogue");

            migrationBuilder.CreateTable(
                name: "Authors",
                schema: "catalogue",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    FullName = table.Column<string>(nullable: true, computedColumnSql: "[FirstName] + ' ' + [LastName]"),
                    Bio = table.Column<string>(nullable: true),
                    AuthorType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                schema: "catalogue",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false, defaultValueSql: "NEXT VALUE FOR catalogue.PublisherIds"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Address_Street = table.Column<string>(nullable: true),
                    Address_Building = table.Column<string>(nullable: true),
                    Address_Apartment = table.Column<string>(nullable: true),
                    Address_City = table.Column<string>(nullable: true),
                    Address_ZipCode = table.Column<string>(nullable: true),
                    Address_Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                schema: "catalogue",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    ISBN = table.Column<string>(maxLength: 13, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    AverageRating = table.Column<decimal>(type: "decimal(3,2)", nullable: false, defaultValue: 0m),
                    IsIllustrated = table.Column<bool>(nullable: false),
                    State = table.Column<string>(maxLength: 20, nullable: false, defaultValue: "Active"),
                    PublisherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.UniqueConstraint("AK_Books_ISBN", x => x.ISBN);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalSchema: "catalogue",
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthors",
                schema: "catalogue",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthors", x => new { x.BookId, x.AuthorId });
                    table.ForeignKey(
                        name: "FK_BookAuthors_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalSchema: "catalogue",
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthors_Books_BookId",
                        column: x => x.BookId,
                        principalSchema: "catalogue",
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookIllustrators",
                schema: "catalogue",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false),
                    IllustratorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookIllustrators", x => new { x.BookId, x.IllustratorId });
                    table.ForeignKey(
                        name: "FK_BookIllustrators_Books_BookId",
                        column: x => x.BookId,
                        principalSchema: "catalogue",
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookIllustrators_Authors_IllustratorId",
                        column: x => x.IllustratorId,
                        principalSchema: "catalogue",
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                schema: "catalogue",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rating = table.Column<int>(nullable: false),
                    ReviewerName = table.Column<string>(maxLength: 50, nullable: true),
                    ReviewText = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    BookId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Books_BookId",
                        column: x => x.BookId,
                        principalSchema: "catalogue",
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_AuthorId",
                schema: "catalogue",
                table: "BookAuthors",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BookIllustrators_IllustratorId",
                schema: "catalogue",
                table: "BookIllustrators",
                column: "IllustratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_ISBN",
                schema: "catalogue",
                table: "Books",
                column: "ISBN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                schema: "catalogue",
                table: "Books",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BookId",
                schema: "catalogue",
                table: "Reviews",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthors",
                schema: "catalogue");

            migrationBuilder.DropTable(
                name: "BookIllustrators",
                schema: "catalogue");

            migrationBuilder.DropTable(
                name: "Reviews",
                schema: "catalogue");

            migrationBuilder.DropTable(
                name: "Authors",
                schema: "catalogue");

            migrationBuilder.DropTable(
                name: "Books",
                schema: "catalogue");

            migrationBuilder.DropTable(
                name: "Publishers",
                schema: "catalogue");

            migrationBuilder.DropSequence(
                name: "BooksHiLoSequence",
                schema: "catalogue");

            migrationBuilder.DropSequence(
                name: "EntityFrameworkHiLoSequence",
                schema: "catalogue");

            migrationBuilder.DropSequence(
                name: "PublisherIds",
                schema: "catalogue");
        }
    }
}
