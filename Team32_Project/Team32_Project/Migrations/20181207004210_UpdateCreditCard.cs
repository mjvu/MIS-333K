using Microsoft.EntityFrameworkCore.Migrations;

namespace Team32_Project.Migrations
{
    public partial class UpdateCreditCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Card2",
                table: "CreditCards");

            migrationBuilder.DropColumn(
                name: "Card3",
                table: "CreditCards");

            migrationBuilder.RenameColumn(
                name: "Card1",
                table: "CreditCards",
                newName: "CardNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CardNumber",
                table: "CreditCards",
                newName: "Card1");

            migrationBuilder.AddColumn<string>(
                name: "Card2",
                table: "CreditCards",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Card3",
                table: "CreditCards",
                nullable: true);
        }
    }
}
