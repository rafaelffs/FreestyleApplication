using Microsoft.EntityFrameworkCore.Migrations;

namespace FreestyleApplication.Migrations
{
    public partial class UpdateBattleGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BattleGroups_Users_UserId",
                table: "BattleGroups");

            migrationBuilder.DropIndex(
                name: "IX_BattleGroups_UserId",
                table: "BattleGroups");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BattleGroups");

            migrationBuilder.CreateTable(
                name: "BattleGroupUser",
                columns: table => new
                {
                    BattleGroupsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleGroupUser", x => new { x.BattleGroupsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_BattleGroupUser_BattleGroups_BattleGroupsId",
                        column: x => x.BattleGroupsId,
                        principalTable: "BattleGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BattleGroupUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BattleGroupUser_UsersId",
                table: "BattleGroupUser",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BattleGroupUser");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "BattleGroups",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BattleGroups_UserId",
                table: "BattleGroups",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BattleGroups_Users_UserId",
                table: "BattleGroups",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
