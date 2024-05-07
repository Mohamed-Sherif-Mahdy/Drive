using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Drive.Migrations
{
    /// <inheritdoc />
    public partial class UserToFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a6ff5ed-fb87-478c-900f-ba8d160ca3d4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc3e645b-125e-4d8f-88a2-5875d8cab6a4");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "2a6ff5ed-fb87-478c-900f-ba8d160ca3d4", null, "Admin", "ADMIN" },
                    { "fc3e645b-125e-4d8f-88a2-5875d8cab6a4", null, "User", "USER" }
                });
        }
    }
}
