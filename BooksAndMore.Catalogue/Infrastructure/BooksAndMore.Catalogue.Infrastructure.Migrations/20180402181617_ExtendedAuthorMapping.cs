using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksAndMore.Catalogue.Infrastructure.Data.Migrations
{
    public partial class ExtendedAuthorMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Review",
                newSchema: "catalogue");

            migrationBuilder.RenameTable(
                name: "Publishers",
                newSchema: "catalogue");

            migrationBuilder.RenameTable(
                name: "BookAuthor",
                newSchema: "catalogue");

            migrationBuilder.RenameTable(
                name: "Authors",
                newSchema: "catalogue");

            migrationBuilder.AlterColumn<string>(
                name: "State",
                schema: "catalogue",
                table: "Books",
                nullable: false,
                defaultValueSql: "'Active'",
                oldClrType: typeof(string),
                oldDefaultValueSql: "'Active'");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "catalogue",
                table: "Authors",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "catalogue",
                table: "Authors",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                schema: "catalogue",
                table: "Authors",
                nullable: true,
                computedColumnSql: "[FirstName] + ' ' + [LastName]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                schema: "catalogue",
                table: "Authors");

            migrationBuilder.RenameTable(
                name: "Review",
                schema: "catalogue");

            migrationBuilder.RenameTable(
                name: "Publishers",
                schema: "catalogue");

            migrationBuilder.RenameTable(
                name: "BookAuthor",
                schema: "catalogue");

            migrationBuilder.RenameTable(
                name: "Authors",
                schema: "catalogue");

            migrationBuilder.AlterColumn<string>(
                name: "State",
                schema: "catalogue",
                table: "Books",
                nullable: false,
                defaultValueSql: "'Active'",
                oldClrType: typeof(string),
                oldDefaultValueSql: "'Active'");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Authors",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Authors",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30);
        }
    }
}
