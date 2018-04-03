using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksAndMore.Catalogue.Infrastructure.Data.Migrations
{
    public partial class BookStateFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "State",
                schema: "catalogue",
                table: "Books",
                type: "nvarchar(20)",
                nullable: false,
                defaultValueSql: "N'Active'",
                oldClrType: typeof(string),
                oldDefaultValueSql: "'Active'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "State",
                schema: "catalogue",
                table: "Books",
                nullable: false,
                defaultValueSql: "'Active'",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldDefaultValueSql: "N'Active'");
        }
    }
}
