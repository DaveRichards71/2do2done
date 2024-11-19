using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class _001_AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "FirstName", "LastName", "Mobile", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 7, 6, 53, 48, 817, DateTimeKind.Local).AddTicks(3107), "will@email.com", "Will", "Richards", "1234567890", "Will" },
                    { 2, new DateTime(2024, 11, 7, 6, 53, 48, 817, DateTimeKind.Local).AddTicks(3156), "charlie@email.com", "Charlie", "Houdini", "2345678901", "charlie" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
