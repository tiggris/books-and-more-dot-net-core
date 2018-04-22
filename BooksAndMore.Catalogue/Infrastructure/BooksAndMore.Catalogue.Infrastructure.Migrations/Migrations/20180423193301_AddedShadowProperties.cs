using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksAndMore.Catalogue.Infrastructure.Data.Migrations.Migrations
{
    public partial class AddedShadowProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDateTime",
                schema: "catalogue",
                table: "Books",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDateTime",
                schema: "catalogue",
                table: "Books",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDateTime",
                schema: "catalogue",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "LastUpdateDateTime",
                schema: "catalogue",
                table: "Books");
        }
    }
}
