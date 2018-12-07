using Microsoft.EntityFrameworkCore.Migrations;

namespace Team32_Project.Migrations
{
    public partial class CreditCardUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreditCardNumber",
                table: "CreditCards");

            migrationBuilder.AddColumn<string>(
                name: "Card1",
                table: "CreditCards",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Card2",
                table: "CreditCards",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Card3",
                table: "CreditCards",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Card1",
                table: "CreditCards");

            migrationBuilder.DropColumn(
                name: "Card2",
                table: "CreditCards");

            migrationBuilder.DropColumn(
                name: "Card3",
                table: "CreditCards");

            migrationBuilder.AddColumn<short>(
                name: "CreditCardNumber",
                table: "CreditCards",
                nullable: false,
                defaultValue: (short)0);
        }
    }
}
