using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceServices.Api.Book.Migrations
{
    public partial class SqlServerMigrationStart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    BookId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    PublishDate = table.Column<DateTime>(nullable: true),
                    AuthorGuid = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.BookId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");
        }
    }
}
