using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorBookClient.Server.Data.Migrations
{
    public partial class AddAuthorCategoryAndPublisherTablesToDB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categories VALUES('Arts')");
            migrationBuilder.Sql("INSERT INTO Categories VALUES('Architecture')");
            migrationBuilder.Sql("INSERT INTO Categories VALUES('Social Science')");
            migrationBuilder.Sql("INSERT INTO Categories VALUES('Science')");
            migrationBuilder.Sql("INSERT INTO Categories VALUES('Engineering')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
