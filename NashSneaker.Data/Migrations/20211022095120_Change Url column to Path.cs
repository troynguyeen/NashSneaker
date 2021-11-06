using Microsoft.EntityFrameworkCore.Migrations;

namespace NashSneaker.Migrations
{
    public partial class ChangeUrlcolumntoPath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Image",
                newName: "Path");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Path",
                table: "Image",
                newName: "Url");
        }
    }
}
