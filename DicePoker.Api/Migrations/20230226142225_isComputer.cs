using Microsoft.EntityFrameworkCore.Migrations;

namespace DicePoker.Api.Migrations
{
    public partial class isComputer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsComputer",
                table: "OpponentHand",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsComputer",
                table: "OpponentHand");
        }
    }
}
