using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookHistory.Data.Migrations
{
    public partial class AddingBookEditHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookEditHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DateOfEdit = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Changes = table.Column<string>(type: "text", nullable: true),
                    BookId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookEditHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookEditHistories_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookEditHistories_BookId",
                table: "BookEditHistories",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookEditHistories");
        }
    }
}
