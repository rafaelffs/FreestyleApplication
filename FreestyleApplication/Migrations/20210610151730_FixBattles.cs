using Microsoft.EntityFrameworkCore.Migrations;

namespace FreestyleApplication.Migrations
{
    public partial class FixBattles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompetitionUser_Competition_CompetitionsId",
                table: "CompetitionUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Group_Competition_CompetitionId",
                table: "Group");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Competition",
                table: "Competition");

            migrationBuilder.RenameTable(
                name: "Competition",
                newName: "Competitions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Competitions",
                table: "Competitions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BattleGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Score = table.Column<int>(type: "int", nullable: false),
                    BattleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BattleGroups_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BattleGroups_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BattleGroups_GroupId",
                table: "BattleGroups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleGroups_UserId",
                table: "BattleGroups",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompetitionUser_Competitions_CompetitionsId",
                table: "CompetitionUser",
                column: "CompetitionsId",
                principalTable: "Competitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Group_Competitions_CompetitionId",
                table: "Group",
                column: "CompetitionId",
                principalTable: "Competitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompetitionUser_Competitions_CompetitionsId",
                table: "CompetitionUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Group_Competitions_CompetitionId",
                table: "Group");

            migrationBuilder.DropTable(
                name: "BattleGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Competitions",
                table: "Competitions");

            migrationBuilder.RenameTable(
                name: "Competitions",
                newName: "Competition");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Competition",
                table: "Competition",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompetitionUser_Competition_CompetitionsId",
                table: "CompetitionUser",
                column: "CompetitionsId",
                principalTable: "Competition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Group_Competition_CompetitionId",
                table: "Group",
                column: "CompetitionId",
                principalTable: "Competition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
