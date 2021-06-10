using Microsoft.EntityFrameworkCore.Migrations;

namespace FreestyleApplication.Migrations
{
    public partial class Competitionadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompetitionId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Competition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competition", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Competition_CompetitionId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Competition");

            migrationBuilder.DropIndex(
                name: "IX_Users_CompetitionId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CompetitionId",
                table: "Users");
        }
    }
}
