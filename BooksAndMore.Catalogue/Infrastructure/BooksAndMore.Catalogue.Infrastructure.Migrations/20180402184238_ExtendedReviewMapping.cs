using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksAndMore.Catalogue.Infrastructure.Data.Migrations
{
    public partial class ExtendedReviewMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Books_BookId",
                schema: "catalogue",
                table: "Review");

            migrationBuilder.AlterColumn<string>(
                name: "ReviewerName",
                schema: "catalogue",
                table: "Review",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                schema: "catalogue",
                table: "Review",
                nullable: false,
                defaultValueSql: "GetUtcDate()",
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                schema: "catalogue",
                table: "Review",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "State",
                schema: "catalogue",
                table: "Books",
                nullable: false,
                defaultValueSql: "'Active'",
                oldClrType: typeof(string),
                oldDefaultValueSql: "'Active'");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Books_BookId",
                schema: "catalogue",
                table: "Review");

            migrationBuilder.AlterColumn<string>(
                name: "ReviewerName",
                schema: "catalogue",
                table: "Review",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                schema: "catalogue",
                table: "Review",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GetUtcDate()");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                schema: "catalogue",
                table: "Review",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "State",
                schema: "catalogue",
                table: "Books",
                nullable: false,
                defaultValueSql: "'Active'",
                oldClrType: typeof(string),
                oldDefaultValueSql: "'Active'");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Books_BookId",
                schema: "catalogue",
                table: "Review",
                column: "BookId",
                principalSchema: "catalogue",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
