using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Drive.Migrations
{
    /// <inheritdoc />
    public partial class User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3979fd7c-d380-4f5d-bac6-6d3a7191ab41");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c39a52fb-1a9e-4f5d-9d87-7ee0069d312b");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "77e87b64-92ef-42fa-8813-253f2dbbe2f1", null, "User", "USER" },
                    { "e159ba0c-1c39-4020-8e5b-93f57bb18c84", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77e87b64-92ef-42fa-8813-253f2dbbe2f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e159ba0c-1c39-4020-8e5b-93f57bb18c84");

            migrationBuilder.AddColumn<string>(
                name: "FileId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3979fd7c-d380-4f5d-bac6-6d3a7191ab41", null, "Admin", "ADMIN" },
                    { "c39a52fb-1a9e-4f5d-9d87-7ee0069d312b", null, "User", "USER" }
                });
        }
    }
}
