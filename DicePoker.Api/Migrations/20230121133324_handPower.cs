using Microsoft.EntityFrameworkCore.Migrations;

namespace DicePoker.Api.Migrations
{
    public partial class handPower : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HandPower",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HandId = table.Column<int>(type: "int", nullable: false),
                    handPowerType = table.Column<int>(type: "int", nullable: false),
                    LeadNumber = table.Column<int>(type: "int", nullable: false),
                    FollowingNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HandPower", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HandPower");
        }
    }
}
