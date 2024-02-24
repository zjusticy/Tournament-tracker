using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TournamentTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TeamNullableInMatchupEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchupEntries_Teams_TeamId",
                table: "MatchupEntries");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "MatchupEntries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchupEntries_Teams_TeamId",
                table: "MatchupEntries",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchupEntries_Teams_TeamId",
                table: "MatchupEntries");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "MatchupEntries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchupEntries_Teams_TeamId",
                table: "MatchupEntries",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
