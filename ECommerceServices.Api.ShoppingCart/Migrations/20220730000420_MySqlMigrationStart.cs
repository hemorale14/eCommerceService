using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;
using System;

namespace ECommerceServices.Api.ShoppingCart.Migrations
{
    public partial class MySqlMigrationStart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SessionHeader",
                columns: table => new
                {
                    SessionHeaderId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionHeader", x => x.SessionHeaderId);
                });

            migrationBuilder.CreateTable(
                name: "SessionDetail",
                columns: table => new
                {
                    SessionDetailId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    ProductSelected = table.Column<string>(nullable: true),
                    SessionHeaderId = table.Column<int>(nullable: false),
                    SessionHeader = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionDetail", x => x.SessionDetailId);
                    table.ForeignKey(
                        name: "FK_SessionDetail_SessionHeader_SessionHeaderId",
                        column: x => x.SessionHeaderId,
                        principalTable: "SessionHeader",
                        principalColumn: "SessionHeaderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SessionDetail_SessionHeaderId",
                table: "SessionDetail",
                column: "SessionHeaderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SessionDetail");

            migrationBuilder.DropTable(
                name: "SessionHeader");
        }
    }
}
