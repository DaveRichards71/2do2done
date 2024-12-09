using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Remove_Seed_Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "FirstName", "LastName", "Mobile", "Password" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 9, 13, 24, 34, 431, DateTimeKind.Local).AddTicks(1615), "linguistwill@gmail.com", "Will", "Richards", "5746993344", "ChangeMe!" },
                    { 2, new DateTime(2024, 12, 9, 13, 24, 34, 431, DateTimeKind.Local).AddTicks(1619), "chueni@horsesaddleshop.com", "Charlie", "Hueni", "5742481595", "ChangeMe!" },
                    { 3, new DateTime(2024, 12, 9, 13, 24, 34, 431, DateTimeKind.Local).AddTicks(1622), "daverichards71.com", "Dave", "Richards", "5745143961", "ChangeMe!" }
                });
        }
    }
}
