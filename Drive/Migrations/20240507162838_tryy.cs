using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Drive.Migrations
{
    /// <inheritdoc />
    public partial class tryy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be505655-02bd-456e-bb13-58f9f3fae9a6"
            );

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cfd7388e-56e2-4a1f-8082-cb5b47abaff5"
            );

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "781c501e-947c-4105-b6bb-37acc2263a62", null, "Admin", "ADMIN" },
                    { "c713cf4f-c05c-4dfc-a6ab-71acc15f8a44", null, "User", "USER" }
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "781c501e-947c-4105-b6bb-37acc2263a62"
            );

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c713cf4f-c05c-4dfc-a6ab-71acc15f8a44"
            );

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "be505655-02bd-456e-bb13-58f9f3fae9a6", null, "User", "USER" },
                    { "cfd7388e-56e2-4a1f-8082-cb5b47abaff5", null, "Admin", "ADMIN" }
                }
            );
        }
    }
}
