using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameAssistant.Data.Wingspan.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "wingspan");

            migrationBuilder.CreateTable(
                name: "Games",
                schema: "wingspan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HasOceaniaExpansion = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerStates",
                schema: "wingspan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PlayerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    Eggs = table.Column<int>(type: "int", nullable: false),
                    FoodOnCards = table.Column<int>(type: "int", nullable: false),
                    TuckedCards = table.Column<int>(type: "int", nullable: false),
                    PointsForBirds = table.Column<int>(type: "int", nullable: false),
                    PointsForObjectives = table.Column<int>(type: "int", nullable: false),
                    NectarOnRow1 = table.Column<int>(type: "int", nullable: false),
                    NectarOnRow2 = table.Column<int>(type: "int", nullable: false),
                    NectarOnRow3 = table.Column<int>(type: "int", nullable: false),
                    EndOfRoundGoals = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerStates_Games_GameId",
                        column: x => x.GameId,
                        principalSchema: "wingspan",
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStates_GameId",
                schema: "wingspan",
                table: "PlayerStates",
                column: "GameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerStates",
                schema: "wingspan");

            migrationBuilder.DropTable(
                name: "Games",
                schema: "wingspan");
        }
    }
}
