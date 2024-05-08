using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Drive.Migrations
{
    /// <inheritdoc />
    public partial class updatefiledata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04588922-211b-4cf4-8d40-c31e4434e2f2"
            );

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d3cf401-184d-4a90-b98c-8f74e7bf942a"
            );

            migrationBuilder.DropColumn(name: "Description", table: "Files");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c865092b-acfb-49be-a052-cdc81ccc968e", null, "Admin", "ADMIN" },
                    { "ef7f690a-baf8-4506-9643-34e7add7cf92", null, "User", "USER" }
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c865092b-acfb-49be-a052-cdc81ccc968e"
            );

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef7f690a-baf8-4506-9643-34e7add7cf92"
            );

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Files",
                type: "nvarchar(max)",
                nullable: true
            );

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "04588922-211b-4cf4-8d40-c31e4434e2f2", null, "User", "USER" },
                    { "8d3cf401-184d-4a90-b98c-8f74e7bf942a", null, "Admin", "ADMIN" }
                }
            );
        }
    }
}
