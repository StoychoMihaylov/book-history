using Microsoft.EntityFrameworkCore.Migrations;

namespace BookHistory.Data.Migrations
{
    public partial class BookEditHistoryUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Changes",
                table: "BookEditHistories",
                newName: "TitleChanges");

            migrationBuilder.AddColumn<string>(
                name: "AuthorChanges",
                table: "BookEditHistories",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionChanges",
                table: "BookEditHistories",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorChanges",
                table: "BookEditHistories");

            migrationBuilder.DropColumn(
                name: "DescriptionChanges",
                table: "BookEditHistories");

            migrationBuilder.RenameColumn(
                name: "TitleChanges",
                table: "BookEditHistories",
                newName: "Changes");
        }
    }
}
