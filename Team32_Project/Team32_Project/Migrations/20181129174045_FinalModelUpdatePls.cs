using Microsoft.EntityFrameworkCore.Migrations;

namespace Team32_Project.Migrations
{
    public partial class FinalModelUpdatePls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Books");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Quantity",
                table: "Books",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
