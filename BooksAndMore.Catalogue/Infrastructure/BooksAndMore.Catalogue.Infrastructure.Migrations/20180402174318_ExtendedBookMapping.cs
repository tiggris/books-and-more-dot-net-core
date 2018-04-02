using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksAndMore.Catalogue.Infrastructure.Data.Migrations
{
    public partial class ExtendedBookMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Publishers_PublisherId",
                table: "Books");

            migrationBuilder.EnsureSchema(
                name: "catalogue");

            migrationBuilder.RenameTable(
                name: "Books",
                newSchema: "catalogue");

            migrationBuilder.RenameColumn(
                name: "Isbn",
                schema: "catalogue",
                table: "Books",
                newName: "ISBN");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "catalogue",
                table: "Books",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PublisherId",
                schema: "catalogue",
                table: "Books",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                schema: "catalogue",
                table: "Books",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AverageRating",
                schema: "catalogue",
                table: "Books",
                type: "decimal(3,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "State",
                schema: "catalogue",
                table: "Books",
                nullable: false,
                defaultValueSql: "'Active'");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Books_ISBN",
                schema: "catalogue",
                table: "Books",
                column: "ISBN");

            migrationBuilder.CreateIndex(
                name: "IX_Books_ISBN",
                schema: "catalogue",
                table: "Books",
                column: "ISBN",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Publishers_PublisherId",
                schema: "catalogue",
                table: "Books",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Publishers_PublisherId",
                schema: "catalogue",
                table: "Books");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Books_ISBN",
                schema: "catalogue",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_ISBN",
                schema: "catalogue",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AverageRating",
                schema: "catalogue",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "State",
                schema: "catalogue",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "Books",
                schema: "catalogue");

            migrationBuilder.RenameColumn(
                name: "ISBN",
                table: "Books",
                newName: "Isbn");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Books",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "PublisherId",
                table: "Books",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Isbn",
                table: "Books",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 13);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Publishers_PublisherId",
                table: "Books",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
