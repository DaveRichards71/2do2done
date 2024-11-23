using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUser_RemoveUsername_AddPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "Password");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2024, 11, 21, 9, 20, 46, 232, DateTimeKind.Local).AddTicks(1577), "ChangeMe!" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2024, 11, 21, 9, 20, 46, 232, DateTimeKind.Local).AddTicks(1581), "ChangeMe!" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "Username");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Username" },
                values: new object[] { new DateTime(2024, 11, 7, 13, 29, 58, 966, DateTimeKind.Local).AddTicks(9407), "Will" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Username" },
                values: new object[] { new DateTime(2024, 11, 7, 13, 29, 58, 966, DateTimeKind.Local).AddTicks(9411), "charlie" });
        }
    }
}
