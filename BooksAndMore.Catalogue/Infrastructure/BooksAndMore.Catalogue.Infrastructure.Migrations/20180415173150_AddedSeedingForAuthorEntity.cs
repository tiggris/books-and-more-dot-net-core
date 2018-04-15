using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksAndMore.Catalogue.Infrastructure.Data.Migrations
{
    public partial class AddedSeedingForAuthorEntity : Migration
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
                oldType: "nvarchar(20)",
                oldNullable: true,
                oldDefaultValueSql: "N'Active'");

            migrationBuilder.InsertData(
                schema: "catalogue",
                table: "Authors",
                columns: new[] { "Id", "AuthorType", "Bio", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, 0, null, "Adam", "Mickiewicz" },
                    { 2, 0, null, "Juliusz", "Słowacki" },
                    { 3, 0, null, "William", "Shakespeare" },
                    { 4, 0, null, "H.P", "Lovecraft" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AlterColumn<string>(
                name: "State",
                schema: "catalogue",
                table: "Books",
                type: "nvarchar(20)",
                nullable: true,
                defaultValueSql: "N'Active'",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldDefaultValueSql: "N'Active'");
        }
    }
}
