using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webAPI.Migrations
{
    /// <inheritdoc />
    public partial class portfoliom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "081c9d3c-96ce-4ec0-8156-5505a3baa1fc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11628cdc-cc56-422d-b6a7-a1d92795638f");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Portfolios");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "64c27314-036c-4555-a4db-5c4a266c9c5b", null, "User", "USER" },
                    { "fc9a0b22-1e5b-4ddd-b257-eba048aafdfb", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64c27314-036c-4555-a4db-5c4a266c9c5b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc9a0b22-1e5b-4ddd-b257-eba048aafdfb");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Portfolios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "081c9d3c-96ce-4ec0-8156-5505a3baa1fc", null, "Admin", "ADMIN" },
                    { "11628cdc-cc56-422d-b6a7-a1d92795638f", null, "User", "USER" }
                });
        }
    }
}
