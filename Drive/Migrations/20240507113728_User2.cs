using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Drive.Migrations
{
    /// <inheritdoc />
    public partial class User2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77e87b64-92ef-42fa-8813-253f2dbbe2f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e159ba0c-1c39-4020-8e5b-93f57bb18c84");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e59eab2d-e5d2-4e8f-b84a-f1bf578fc85c", null, "User", "USER" },
                    { "fc6a7eb9-6e39-4748-af65-ed443b934ff1", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e59eab2d-e5d2-4e8f-b84a-f1bf578fc85c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc6a7eb9-6e39-4748-af65-ed443b934ff1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "77e87b64-92ef-42fa-8813-253f2dbbe2f1", null, "User", "USER" },
                    { "e159ba0c-1c39-4020-8e5b-93f57bb18c84", null, "Admin", "ADMIN" }
                });
        }
    }
}
