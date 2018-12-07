using Microsoft.EntityFrameworkCore.Migrations;

namespace Team32_Project.Migrations
{
    public partial class UpdateModelsAGAIN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderTotal",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "ReorderType",
                table: "Reorders",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AddColumn<decimal>(
                name: "ExtendedCost",
                table: "ReorderDetails",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExtendedCost",
                table: "ReorderDetails");

            migrationBuilder.AlterColumn<bool>(
                name: "ReorderType",
                table: "Reorders",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<decimal>(
                name: "OrderTotal",
                table: "Orders",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
