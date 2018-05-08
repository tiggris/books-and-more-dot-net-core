using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksAndMore.Catalogue.Infrastructure.Data.Migrations.Migrations
{
    public partial class AddedDataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "EntityFrameworkHiLoSequence",
                schema: "catalogue");

            migrationBuilder.CreateSequence<int>(
                name: "AuthorsHiLoSequence",
                schema: "catalogue",
                startValue: 100L,
                incrementBy: 100);
            
            migrationBuilder.RestartSequence(
                name: "PublisherIds",
                schema: "catalogue",
                startValue: 100L);

            migrationBuilder.RestartSequence(
                name: "BooksHiLoSequence",
                schema: "catalogue",
                startValue: 100L);

            migrationBuilder.InsertData(
                schema: "catalogue",
                table: "Authors",
                columns: new[] { "Id", "AuthorType", "Bio", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, 0, null, "Adam", "Mickiewicz" },
                    { 2, 0, null, "Juliusz", "Słowacki" },
                    { 3, 0, null, "William", "Shakespeare" },
                    { 4, 0, null, "H.P", "Lovecraft" },
                    { 5, 0, null, "Antoine", "de Saint-Exupéry" },
                    { 6, 0, null, "A.A", "Milne" },
                    { 7, 1, null, "Antoine", "de Saint-Exupéry" },
                    { 8, 1, null, "Ernest Howard", "Shepard" }
                });

            migrationBuilder.InsertData(
                schema: "catalogue",
                table: "Publishers",
                columns: new[] { "Id", "Name", "Address_Apartment", "Address_Building", "Address_City", "Address_Country", "Address_Street", "Address_ZipCode" },
                values: new object[,]
                {
                    { 1, "Wydawnictwo Rebis", null, null, null, null, null, null },
                    { 2, "Czarna Owca", null, null, null, null, null, null },
                    { 3, "Wydawnictwo Znak", null, null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                schema: "catalogue",
                table: "Books",
                columns: new[] { "Id", "ISBN", "State", "Title", "AverageRating", "CreateDateTime", "Description", "IsIllustrated", "LastUpdateDateTime", "PublisherId" },
                values: new object[,]
                {
                    { 1, "9788388736919", "Active", "Pan Tadeusz", 0m, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "9788373899285", "Active", "Dziady", 0m, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, "9780313208287", "Active", "Anhelli", 0m, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 10, "9781387317844", "Active", "Romeo i Julia", 0m, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 11, "9789510422311", "Active", "Ryszard III", 0m, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 14, "9782230001040", "Active", "Kubuś Puchatek", 0m, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, "9781500143640", "Active", "Sonety Krymskie", 0m, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, "9788377916605", "Active", "Balladyna", 0m, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 8, "9788496509290", "Deleted", "Makbet", 0m, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 9, "9781348101864", "Active", "Hamlet", 0m, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, "9781498181334", "Active", "Konrad Wallenrod", 0m, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 7, "9876543210112", "Active", "Książka, której nigdy nie było", 0m, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 12, "9781480297890", "Active", "Wiele hałasu o nic", 0m, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 13, "9788995317471", "Active", "Mały Książę", 0m, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.InsertData(
                schema: "catalogue",
                table: "BookAuthors",
                columns: new[] { "BookId", "AuthorId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 12, 3 },
                    { 7, 2 },
                    { 7, 1 },
                    { 4, 1 },
                    { 2, 1 },
                    { 9, 3 },
                    { 8, 3 },
                    { 6, 2 },
                    { 5, 2 },
                    { 13, 5 },
                    { 3, 1 },
                    { 10, 3 },
                    { 14, 6 },
                    { 11, 3 }
                });

            migrationBuilder.InsertData(
                schema: "catalogue",
                table: "BookIllustrators",
                columns: new[] { "BookId", "IllustratorId" },
                values: new object[,]
                {
                    { 14, 8 },
                    { 13, 7 }
                });

            migrationBuilder.InsertData(
                schema: "catalogue",
                table: "Reviews",
                columns: new[] { "Id", "BookId", "CreateDate", "Rating", "ReviewText", "ReviewerName" },
                values: new object[,]
                {
                    { 30, 10, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, null, null },
                    { 1, 1, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, null },
                    { 24, 7, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, null, null },
                    { 23, 7, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null },
                    { 22, 7, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, null },
                    { 2, 1, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, null },
                    { 3, 1, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, null, null },
                    { 9, 4, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, null, null },
                    { 8, 4, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, null },
                    { 4, 1, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, null, null },
                    { 26, 9, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, null, null },
                    { 5, 2, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, null },
                    { 25, 8, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, null },
                    { 6, 2, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, null },
                    { 17, 5, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, null, null },
                    { 16, 5, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, null, null },
                    { 15, 5, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, null },
                    { 14, 5, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, null, null },
                    { 13, 5, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, null },
                    { 12, 5, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, null },
                    { 11, 5, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, null },
                    { 10, 5, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null },
                    { 18, 6, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null },
                    { 19, 6, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, null },
                    { 20, 6, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, null },
                    { 21, 6, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, null, null },
                    { 27, 10, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, null },
                    { 32, 11, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, null, null },
                    { 31, 11, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, null, null },
                    { 28, 10, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, null },
                    { 29, 10, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null },
                    { 7, 3, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "AuthorsHiLoSequence",
                schema: "catalogue");

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "BookAuthors",
                keyColumns: new[] { "BookId", "AuthorId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "BookAuthors",
                keyColumns: new[] { "BookId", "AuthorId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "BookAuthors",
                keyColumns: new[] { "BookId", "AuthorId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "BookAuthors",
                keyColumns: new[] { "BookId", "AuthorId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "BookAuthors",
                keyColumns: new[] { "BookId", "AuthorId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "BookAuthors",
                keyColumns: new[] { "BookId", "AuthorId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "BookAuthors",
                keyColumns: new[] { "BookId", "AuthorId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "BookAuthors",
                keyColumns: new[] { "BookId", "AuthorId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "BookAuthors",
                keyColumns: new[] { "BookId", "AuthorId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "BookAuthors",
                keyColumns: new[] { "BookId", "AuthorId" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "BookAuthors",
                keyColumns: new[] { "BookId", "AuthorId" },
                keyValues: new object[] { 10, 3 });

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "BookAuthors",
                keyColumns: new[] { "BookId", "AuthorId" },
                keyValues: new object[] { 11, 3 });

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "BookAuthors",
                keyColumns: new[] { "BookId", "AuthorId" },
                keyValues: new object[] { 12, 3 });

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "BookAuthors",
                keyColumns: new[] { "BookId", "AuthorId" },
                keyValues: new object[] { 13, 5 });

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "BookAuthors",
                keyColumns: new[] { "BookId", "AuthorId" },
                keyValues: new object[] { 14, 6 });

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "BookIllustrators",
                keyColumns: new[] { "BookId", "IllustratorId" },
                keyValues: new object[] { 13, 7 });

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "BookIllustrators",
                keyColumns: new[] { "BookId", "IllustratorId" },
                keyValues: new object[] { 14, 8 });

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 32);

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
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Authors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Authors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Books",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Books",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Books",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Books",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "catalogue",
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.CreateSequence(
                name: "EntityFrameworkHiLoSequence",
                schema: "catalogue",
                incrementBy: 10);
            
            migrationBuilder.RestartSequence(
                name: "PublisherIds",
                schema: "catalogue",
                startValue: 1L);

            migrationBuilder.RestartSequence(
                name: "BooksHiLoSequence",
                schema: "catalogue",
                startValue: 1L);
        }
    }
}
