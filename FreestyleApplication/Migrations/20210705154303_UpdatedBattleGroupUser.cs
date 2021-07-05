using Microsoft.EntityFrameworkCore.Migrations;

namespace FreestyleApplication.Migrations
{
    public partial class UpdatedBattleGroupUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BattleGroupsUsersTest");

            migrationBuilder.DropTable(
                name: "BattleGroupUser");

            migrationBuilder.CreateTable(
                name: "BattleGroupsUsers",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BattleGroupId = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleGroupsUsers", x => new { x.UserId, x.BattleGroupId });
                    table.ForeignKey(
                        name: "FK_BattleGroupsUsers_BattleGroups_BattleGroupId",
                        column: x => x.BattleGroupId,
                        principalTable: "BattleGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BattleGroupsUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BattleGroupsUsers_BattleGroupId",
                table: "BattleGroupsUsers",
                column: "BattleGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BattleGroupsUsers");

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
                name: "IX_BattleGroupsUsersTest_BattleGroupId",
                table: "BattleGroupsUsersTest",
                column: "BattleGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleGroupUser_UsersId",
                table: "BattleGroupUser",
                column: "UsersId");
        }
    }
}
