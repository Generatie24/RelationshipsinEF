using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneToManyDemo.Migrations
{
    /// <inheritdoc />
    public partial class changedbookmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BindingType",
                table: "Boeks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Boeks",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsBestSeller",
                table: "Boeks",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsNewRelease",
                table: "Boeks",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Boeks",
                keyColumn: "BoekId",
                keyValue: 1,
                columns: new[] { "BindingType", "IsAvailable", "IsBestSeller", "IsNewRelease" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Boeks",
                keyColumn: "BoekId",
                keyValue: 2,
                columns: new[] { "BindingType", "IsAvailable", "IsBestSeller", "IsNewRelease" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Boeks",
                keyColumn: "BoekId",
                keyValue: 3,
                columns: new[] { "BindingType", "IsAvailable", "IsBestSeller", "IsNewRelease" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Boeks",
                keyColumn: "BoekId",
                keyValue: 4,
                columns: new[] { "BindingType", "IsAvailable", "IsBestSeller", "IsNewRelease" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Boeks",
                keyColumn: "BoekId",
                keyValue: 5,
                columns: new[] { "BindingType", "IsAvailable", "IsBestSeller", "IsNewRelease" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Boeks",
                keyColumn: "BoekId",
                keyValue: 6,
                columns: new[] { "BindingType", "IsAvailable", "IsBestSeller", "IsNewRelease" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Boeks",
                keyColumn: "BoekId",
                keyValue: 7,
                columns: new[] { "BindingType", "IsAvailable", "IsBestSeller", "IsNewRelease" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Boeks",
                keyColumn: "BoekId",
                keyValue: 8,
                columns: new[] { "BindingType", "IsAvailable", "IsBestSeller", "IsNewRelease" },
                values: new object[] { null, null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BindingType",
                table: "Boeks");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Boeks");

            migrationBuilder.DropColumn(
                name: "IsBestSeller",
                table: "Boeks");

            migrationBuilder.DropColumn(
                name: "IsNewRelease",
                table: "Boeks");
        }
    }
}
