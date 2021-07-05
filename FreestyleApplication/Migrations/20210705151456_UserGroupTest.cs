using Microsoft.EntityFrameworkCore.Migrations;

namespace FreestyleApplication.Migrations
{
    public partial class UserGroupTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BattleGroupsUsersTest",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BattleGroupId = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleGroupsUsersTest", x => new { x.UserId, x.BattleGroupId });
                    table.ForeignKey(
                        name: "FK_BattleGroupsUsersTest_BattleGroups_BattleGroupId",
                        column: x => x.BattleGroupId,
                        principalTable: "BattleGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BattleGroupsUsersTest_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BattleGroupsUsersTest_BattleGroupId",
                table: "BattleGroupsUsersTest",
                column: "BattleGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BattleGroupsUsersTest");
        }
    }
}
