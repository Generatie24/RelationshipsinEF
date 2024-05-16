using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneToManyDemo.Migrations
{
    /// <inheritdoc />
    public partial class recor8added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Boeks",
                columns: new[] { "BoekId", "AuteurId", "Titel" },
                values: new object[] { 8, 3, "De avonturen van Code 8" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Boeks",
                keyColumn: "BoekId",
                keyValue: 8);
        }
    }
}
