using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicApp.Migrations
{
    /// <inheritdoc />
    public partial class CardType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CardSuperTypes",
                keyColumns: new[] { "CardId", "SuperTypeId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.CreateTable(
                name: "CardTypes",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardTypes", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "CardCardTypes",
                columns: table => new
                {
                    CardId = table.Column<int>(type: "int", nullable: false),
                    CardTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardCardTypes", x => new { x.CardId, x.CardTypeId });
                    table.ForeignKey(
                        name: "FK_CardCardTypes_CardTypes_CardTypeId",
                        column: x => x.CardTypeId,
                        principalTable: "CardTypes",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardCardTypes_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "CardId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CardTypes",
                columns: new[] { "TypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Artifact" },
                    { 2, "Enchantment" },
                    { 3, "Creature" },
                    { 4, "Land" },
                    { 5, "Planeswalker" },
                    { 6, "Battle" },
                    { 7, "Instant" },
                    { 8, "Sorcery" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardCardTypes_CardTypeId",
                table: "CardCardTypes",
                column: "CardTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardCardTypes");

            migrationBuilder.DropTable(
                name: "CardTypes");

            migrationBuilder.InsertData(
                table: "CardSuperTypes",
                columns: new[] { "CardId", "SuperTypeId" },
                values: new object[] { 4, 2 });
        }
    }
}
