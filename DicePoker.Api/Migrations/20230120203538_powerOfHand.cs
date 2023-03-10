using Microsoft.EntityFrameworkCore.Migrations;

namespace DicePoker.Api.Migrations
{
    public partial class powerOfHand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PowerOfHand",
                table: "Hand",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PowerOfHand",
                table: "Hand");
        }
    }
}
