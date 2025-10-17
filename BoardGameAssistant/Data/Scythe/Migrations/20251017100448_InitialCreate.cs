using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameAssistant.Data.Scythe.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "scythe");

            migrationBuilder.CreateTable(
                name: "Games",
                schema: "scythe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HasInvadersFromAfarExpansion = table.Column<bool>(type: "bit", nullable: false),
                    HasWindGambitExpansion = table.Column<bool>(type: "bit", nullable: false),
                    HasRiseOfFenrisExpansion = table.Column<bool>(type: "bit", nullable: false),
                    HasModularBoard = table.Column<bool>(type: "bit", nullable: false),
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
                schema: "scythe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PlayerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    Faction = table.Column<string>(type: "CHAR(12)", maxLength: 12, nullable: false),
                    Coins = table.Column<int>(type: "int", nullable: false),
                    Popularity = table.Column<int>(type: "int", nullable: false),
                    Power = table.Column<int>(type: "int", nullable: false),
                    Food = table.Column<int>(type: "int", nullable: false),
                    Wood = table.Column<int>(type: "int", nullable: false),
                    Metal = table.Column<int>(type: "int", nullable: false),
                    Oil = table.Column<int>(type: "int", nullable: false),
                    Workers = table.Column<int>(type: "int", nullable: false),
                    Stars = table.Column<int>(type: "int", nullable: false),
                    TerritoriesControlled = table.Column<int>(type: "int", nullable: false),
                    HasFactory = table.Column<bool>(type: "bit", nullable: false),
                    StructuresBuilt = table.Column<int>(type: "int", nullable: false),
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
                        principalSchema: "scythe",
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStates_GameId",
                schema: "scythe",
                table: "PlayerStates",
                column: "GameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerStates",
                schema: "scythe");

            migrationBuilder.DropTable(
                name: "Games",
                schema: "scythe");
        }
    }
}
