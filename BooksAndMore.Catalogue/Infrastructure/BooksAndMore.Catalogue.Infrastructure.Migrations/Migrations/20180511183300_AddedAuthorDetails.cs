using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksAndMore.Catalogue.Infrastructure.Data.Migrations.Migrations
{
    public partial class AddedAuthorDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                schema: "catalogue",
                table: "Authors",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "catalogue",
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Bio", "BirthDate" },
                values: new object[] { "Adam Bernard Mickiewicz herbu Poraj – polski poeta, działacz polityczny, publicysta, tłumacz, filozof, działacz religijny, mistyk, organizator i dowódca wojskowy, nauczyciel akademicki.", new DateTime(1798, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                schema: "catalogue",
                table: "Authors");

            migrationBuilder.UpdateData(
                schema: "catalogue",
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Bio" },
                values: new object[] { null });
        }
    }
}
