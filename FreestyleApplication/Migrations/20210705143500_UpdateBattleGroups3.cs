using Microsoft.EntityFrameworkCore.Migrations;

namespace FreestyleApplication.Migrations
{
    public partial class UpdateBattleGroups3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score",
                table: "BattleGroups");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "BattleGroups",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
