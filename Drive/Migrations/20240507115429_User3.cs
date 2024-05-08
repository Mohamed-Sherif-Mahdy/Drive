using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Drive.Migrations
{
    /// <inheritdoc />
    public partial class User3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e59eab2d-e5d2-4e8f-b84a-f1bf578fc85c"
            );

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc6a7eb9-6e39-4748-af65-ed443b934ff1"
            );

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d939db8d-1d2e-434e-9481-f0321a7deb49", null, "User", "USER" },
                    { "ea3ed385-8117-4a79-b1fc-151d690d3340", null, "Admin", "ADMIN" }
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d939db8d-1d2e-434e-9481-f0321a7deb49"
            );

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea3ed385-8117-4a79-b1fc-151d690d3340"
            );

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e59eab2d-e5d2-4e8f-b84a-f1bf578fc85c", null, "User", "USER" },
                    { "fc6a7eb9-6e39-4748-af65-ed443b934ff1", null, "Admin", "ADMIN" }
                }
            );
        }
    }
}
