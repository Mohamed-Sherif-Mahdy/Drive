using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Drive.Migrations
{
    /// <inheritdoc />
    public partial class @try : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Files_AspNetUsers_UserId", table: "Files");

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
                    { "be505655-02bd-456e-bb13-58f9f3fae9a6", null, "User", "USER" },
                    { "cfd7388e-56e2-4a1f-8082-cb5b47abaff5", null, "Admin", "ADMIN" }
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Files_AspNetUsers_UserName", table: "Files");

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
                    { "d939db8d-1d2e-434e-9481-f0321a7deb49", null, "User", "USER" },
                    { "ea3ed385-8117-4a79-b1fc-151d690d3340", null, "Admin", "ADMIN" }
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
    }
}
