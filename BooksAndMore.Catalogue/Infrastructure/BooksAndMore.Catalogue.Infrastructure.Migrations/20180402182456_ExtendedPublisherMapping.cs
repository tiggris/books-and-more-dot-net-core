using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksAndMore.Catalogue.Infrastructure.Data.Migrations
{
    public partial class ExtendedPublisherMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "catalogue",
                table: "Publishers",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "State",
                schema: "catalogue",
                table: "Books",
                nullable: false,
                defaultValueSql: "'Active'",
                oldClrType: typeof(string),
                oldDefaultValueSql: "'Active'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "catalogue",
                table: "Publishers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "State",
                schema: "catalogue",
                table: "Books",
                nullable: false,
                defaultValueSql: "'Active'",
                oldClrType: typeof(string),
                oldDefaultValueSql: "'Active'");
        }
    }
}
