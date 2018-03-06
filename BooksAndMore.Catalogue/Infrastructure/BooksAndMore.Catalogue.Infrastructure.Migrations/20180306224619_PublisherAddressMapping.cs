using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksAndMore.Catalogue.Infrastructure.Data.Migrations
{
    public partial class PublisherAddressMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AddressZipCode",
                table: "Publishers",
                newName: "Address_ZipCode");

            migrationBuilder.RenameColumn(
                name: "AddressStreet",
                table: "Publishers",
                newName: "Address_Street");

            migrationBuilder.RenameColumn(
                name: "AddressCountry",
                table: "Publishers",
                newName: "Address_Country");

            migrationBuilder.RenameColumn(
                name: "AddressCity",
                table: "Publishers",
                newName: "Address_City");

            migrationBuilder.RenameColumn(
                name: "AddressBuilding",
                table: "Publishers",
                newName: "Address_Building");

            migrationBuilder.RenameColumn(
                name: "AddressApartment",
                table: "Publishers",
                newName: "Address_Apartment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address_ZipCode",
                table: "Publishers",
                newName: "AddressZipCode");

            migrationBuilder.RenameColumn(
                name: "Address_Street",
                table: "Publishers",
                newName: "AddressStreet");

            migrationBuilder.RenameColumn(
                name: "Address_Country",
                table: "Publishers",
                newName: "AddressCountry");

            migrationBuilder.RenameColumn(
                name: "Address_City",
                table: "Publishers",
                newName: "AddressCity");

            migrationBuilder.RenameColumn(
                name: "Address_Building",
                table: "Publishers",
                newName: "AddressBuilding");

            migrationBuilder.RenameColumn(
                name: "Address_Apartment",
                table: "Publishers",
                newName: "AddressApartment");
        }
    }
}
