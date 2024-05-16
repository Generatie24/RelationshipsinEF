using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OneToManyDemo.Migrations
{
    /// <inheritdoc />
    public partial class CreateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auteurs",
                columns: table => new
                {
                    AuteurId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auteurs", x => x.AuteurId);
                });

            migrationBuilder.CreateTable(
                name: "Boeks",
                columns: table => new
                {
                    BoekId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuteurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boeks", x => x.BoekId);
                    table.ForeignKey(
                        name: "FK_Boeks_Auteurs_AuteurId",
                        column: x => x.AuteurId,
                        principalTable: "Auteurs",
                        principalColumn: "AuteurId");
                });

            migrationBuilder.InsertData(
                table: "Auteurs",
                columns: new[] { "AuteurId", "Naam" },
                values: new object[,]
                {
                    { 1, "J.K. Rowling" },
                    { 2, "Stephen King" },
                    { 3, "J.R.R. Tolkien" },
                    { 4, "Dan Brown" }
                });

            migrationBuilder.InsertData(
                table: "Boeks",
                columns: new[] { "BoekId", "AuteurId", "Titel" },
                values: new object[,]
                {
                    { 1, 1, "De avonturen van Code" },
                    { 2, 2, "De avonturen van Code 2" },
                    { 3, 1, "De avonturen van Code 3" },
                    { 4, 3, "De avonturen van Code 4" },
                    { 5, 4, "De avonturen van Code 5" },
                    { 6, 2, "De avonturen van Code 6" },
                    { 7, 4, "De avonturen van Code 7" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boeks_AuteurId",
                table: "Boeks",
                column: "AuteurId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boeks");

            migrationBuilder.DropTable(
                name: "Auteurs");
        }
    }
}
