using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicApp.Migrations
{
    /// <inheritdoc />
    public partial class SuperType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SuperTypes",
                columns: table => new
                {
                    SuperTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperTypes", x => x.SuperTypeId);
                });

            migrationBuilder.CreateTable(
                name: "CardSuperTypes",
                columns: table => new
                {
                    CardId = table.Column<int>(type: "int", nullable: false),
                    SuperTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardSuperTypes", x => new { x.CardId, x.SuperTypeId });
                    table.ForeignKey(
                        name: "FK_CardSuperTypes_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "CardId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardSuperTypes_SuperTypes_SuperTypeId",
                        column: x => x.SuperTypeId,
                        principalTable: "SuperTypes",
                        principalColumn: "SuperTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SuperTypes",
                columns: new[] { "SuperTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Basic" },
                    { 2, "Legendary" },
                    { 3, "Snow" },
                    { 4, "World" }
                });

            migrationBuilder.InsertData(
                table: "CardSuperTypes",
                columns: new[] { "CardId", "SuperTypeId" },
                values: new object[] { 9, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_CardSuperTypes_SuperTypeId",
                table: "CardSuperTypes",
                column: "SuperTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardSuperTypes");

            migrationBuilder.DropTable(
                name: "SuperTypes");
        }
    }
}
