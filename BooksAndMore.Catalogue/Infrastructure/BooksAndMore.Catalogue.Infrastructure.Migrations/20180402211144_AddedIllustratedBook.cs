using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksAndMore.Catalogue.Infrastructure.Data.Migrations
{
    public partial class AddedIllustratedBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthor_Authors_AuthorId",
                schema: "catalogue",
                table: "BookAuthor");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthor_Books_BookId",
                schema: "catalogue",
                table: "BookAuthor");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Books_BookId",
                schema: "catalogue",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                schema: "catalogue",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookAuthor",
                schema: "catalogue",
                table: "BookAuthor");

            migrationBuilder.RenameTable(
                name: "Review",
                schema: "catalogue",
                newName: "Reviews");

            migrationBuilder.RenameTable(
                name: "BookAuthor",
                schema: "catalogue",
                newName: "BookAuthors");

            migrationBuilder.RenameIndex(
                name: "IX_Review_BookId",
                schema: "catalogue",
                table: "Reviews",
                newName: "IX_Reviews_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_BookAuthor_AuthorId",
                schema: "catalogue",
                table: "BookAuthors",
                newName: "IX_BookAuthors_AuthorId");

            migrationBuilder.AlterColumn<string>(
                name: "State",
                schema: "catalogue",
                table: "Books",
                nullable: false,
                defaultValueSql: "'Active'",
                oldClrType: typeof(string),
                oldDefaultValueSql: "'Active'");

            migrationBuilder.AddColumn<bool>(
                name: "IsIllustrated",
                schema: "catalogue",
                table: "Books",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "AuthorType",
                schema: "catalogue",
                table: "Authors",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                schema: "catalogue",
                table: "Reviews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookAuthors",
                schema: "catalogue",
                table: "BookAuthors",
                columns: new[] { "BookId", "AuthorId" });

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

            migrationBuilder.CreateIndex(
                name: "IX_BookIllustrators_IllustratorId",
                schema: "catalogue",
                table: "BookIllustrators",
                column: "IllustratorId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthors_Authors_AuthorId",
                schema: "catalogue",
                table: "BookAuthors",
                column: "AuthorId",
                principalSchema: "catalogue",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthors_Books_BookId",
                schema: "catalogue",
                table: "BookAuthors",
                column: "BookId",
                principalSchema: "catalogue",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Books_BookId",
                schema: "catalogue",
                table: "Reviews",
                column: "BookId",
                principalSchema: "catalogue",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthors_Authors_AuthorId",
                schema: "catalogue",
                table: "BookAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthors_Books_BookId",
                schema: "catalogue",
                table: "BookAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Books_BookId",
                schema: "catalogue",
                table: "Reviews");

            migrationBuilder.DropTable(
                name: "BookIllustrators",
                schema: "catalogue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                schema: "catalogue",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookAuthors",
                schema: "catalogue",
                table: "BookAuthors");

            migrationBuilder.DropColumn(
                name: "IsIllustrated",
                schema: "catalogue",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AuthorType",
                schema: "catalogue",
                table: "Authors");

            migrationBuilder.RenameTable(
                name: "Reviews",
                schema: "catalogue",
                newName: "Review");

            migrationBuilder.RenameTable(
                name: "BookAuthors",
                schema: "catalogue",
                newName: "BookAuthor");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_BookId",
                schema: "catalogue",
                table: "Review",
                newName: "IX_Review_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_BookAuthors_AuthorId",
                schema: "catalogue",
                table: "BookAuthor",
                newName: "IX_BookAuthor_AuthorId");

            migrationBuilder.AlterColumn<string>(
                name: "State",
                schema: "catalogue",
                table: "Books",
                nullable: false,
                defaultValueSql: "'Active'",
                oldClrType: typeof(string),
                oldDefaultValueSql: "'Active'");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                schema: "catalogue",
                table: "Review",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookAuthor",
                schema: "catalogue",
                table: "BookAuthor",
                columns: new[] { "BookId", "AuthorId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthor_Authors_AuthorId",
                schema: "catalogue",
                table: "BookAuthor",
                column: "AuthorId",
                principalSchema: "catalogue",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthor_Books_BookId",
                schema: "catalogue",
                table: "BookAuthor",
                column: "BookId",
                principalSchema: "catalogue",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Books_BookId",
                schema: "catalogue",
                table: "Review",
                column: "BookId",
                principalSchema: "catalogue",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
