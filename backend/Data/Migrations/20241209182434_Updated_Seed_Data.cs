using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Updated_Seed_Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Email", "Mobile" },
                values: new object[] { new DateTime(2024, 12, 9, 13, 24, 34, 431, DateTimeKind.Local).AddTicks(1615), "linguistwill@gmail.com", "5746993344" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Email", "LastName", "Mobile" },
                values: new object[] { new DateTime(2024, 12, 9, 13, 24, 34, 431, DateTimeKind.Local).AddTicks(1619), "chueni@horsesaddleshop.com", "Hueni", "5742481595" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "FirstName", "LastName", "Mobile", "Password" },
                values: new object[] { 3, new DateTime(2024, 12, 9, 13, 24, 34, 431, DateTimeKind.Local).AddTicks(1622), "daverichards71.com", "Dave", "Richards", "5745143961", "ChangeMe!" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Email", "Mobile" },
                values: new object[] { new DateTime(2024, 11, 21, 9, 20, 46, 232, DateTimeKind.Local).AddTicks(1577), "will@email.com", "1234567890" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Email", "LastName", "Mobile" },
                values: new object[] { new DateTime(2024, 11, 21, 9, 20, 46, 232, DateTimeKind.Local).AddTicks(1581), "charlie@email.com", "Houdini", "2345678901" });
        }
    }
}
