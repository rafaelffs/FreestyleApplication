using Microsoft.EntityFrameworkCore.Migrations;

namespace FreestyleApplication.Migrations
{
    public partial class Competition2added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Competition_CompetitionId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CompetitionId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CompetitionId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "CompetitionUser",
                columns: table => new
                {
                    CompetitionsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionUser", x => new { x.CompetitionsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_CompetitionUser_Competition_CompetitionsId",
                        column: x => x.CompetitionsId,
                        principalTable: "Competition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompetitionUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionUser_UsersId",
                table: "CompetitionUser",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompetitionUser");

            migrationBuilder.AddColumn<int>(
                name: "CompetitionId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CompetitionId",
                table: "Users",
                column: "CompetitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Competition_CompetitionId",
                table: "Users",
                column: "CompetitionId",
                principalTable: "Competition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
