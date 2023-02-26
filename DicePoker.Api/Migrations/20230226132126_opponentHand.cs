using Microsoft.EntityFrameworkCore.Migrations;

namespace DicePoker.Api.Migrations
{
    public partial class opponentHand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Hand");

            migrationBuilder.AlterColumn<int>(
                name: "HandId",
                table: "HandPower",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "OpponentHandId",
                table: "HandPower",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OpponentHand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HandNumbers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfThrows = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpponentHand", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OpponentHand");

            migrationBuilder.DropColumn(
                name: "OpponentHandId",
                table: "HandPower");

            migrationBuilder.AlterColumn<int>(
                name: "HandId",
                table: "HandPower",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Hand",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
