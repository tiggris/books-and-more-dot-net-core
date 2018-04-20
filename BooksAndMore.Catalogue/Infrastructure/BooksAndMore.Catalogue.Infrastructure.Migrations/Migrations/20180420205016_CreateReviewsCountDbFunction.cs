using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksAndMore.Catalogue.Infrastructure.Data.Migrations.Migrations
{
    public partial class CreateReviewsCountDbFunction : Migration
    {
        private const string FunctionName = "[catalogue].[ReviewsCount]";

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = $@"CREATE FUNCTION  {FunctionName} (@bookId INT) RETURNS INT
                        AS
                        BEGIN
                            DECLARE @reviewsCount INT 

	                        SELECT @reviewsCount = COUNT(*)
	                        FROM catalogue.Reviews
	                        WHERE BookId = @bookId

	                        RETURN @reviewsCount
                        END";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"DROP FUNCTION {FunctionName}");
        }
    }
}
