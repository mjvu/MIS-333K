using Microsoft.EntityFrameworkCore.Migrations;

namespace Team32_Project.Migrations
{
    public partial class OrderUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "OrderDetails",
                newName: "ExtendedPrice");

            migrationBuilder.AddColumn<int>(
                name: "OrderNumber",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ShippingPrice",
                table: "Orders",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "BookPrice",
                table: "OrderDetails",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShippingPrice",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BookPrice",
                table: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "ExtendedPrice",
                table: "OrderDetails",
                newName: "Price");
        }
    }
}
