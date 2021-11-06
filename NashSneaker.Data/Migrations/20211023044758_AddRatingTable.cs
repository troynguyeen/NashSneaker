using Microsoft.EntityFrameworkCore.Migrations;

namespace NashSneaker.Migrations
{
    public partial class AddRatingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "level",
                table: "Rating",
                newName: "Level");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Level",
                table: "Rating",
                newName: "level");
        }
    }
}
