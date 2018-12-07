using Microsoft.EntityFrameworkCore.Migrations;

namespace Team32_Project.Migrations
{
    public partial class InactiveBookUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Books",
                newName: "Inactive");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Inactive",
                table: "Books",
                newName: "Active");
        }
    }
}
