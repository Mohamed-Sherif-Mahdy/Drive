using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Drive.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Files_AspNetUsers_UserName", table: "Files");

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

            migrationBuilder.RenameColumn(name: "UserName", table: "Files", newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Files_UserName",
                table: "Files",
                newName: "IX_Files_UserId"
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

            migrationBuilder.AddForeignKey(
                name: "FK_Files_AspNetUsers_UserId",
                table: "Files",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Files_AspNetUsers_UserId", table: "Files");

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

            migrationBuilder.RenameColumn(name: "UserId", table: "Files", newName: "UserName");

            migrationBuilder.RenameIndex(
                name: "IX_Files_UserId",
                table: "Files",
                newName: "IX_Files_UserName"
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

            migrationBuilder.AddForeignKey(
                name: "FK_Files_AspNetUsers_UserName",
                table: "Files",
                column: "UserName",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );
        }
    }
}
