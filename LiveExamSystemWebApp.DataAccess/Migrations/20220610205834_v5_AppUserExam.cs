using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiveExamSystemWebApp.DataAccess.Migrations
{
    public partial class v5_AppUserExam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsStarted",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "UserStartDate",
                table: "Exams");

            migrationBuilder.AddColumn<bool>(
                name: "IsStarted",
                table: "AppUserExam",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UserStartDate",
                table: "AppUserExam",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "485ce0f6be26426db799d59a1d2f64a4", "662fa573b1974fe0e5623763e6210a932bbfe85a1a083953f89d020a2617c116b07f861e800babd73d2c77c0977b0606cb60ee36f7eadc3ea8a1c91ea5e91d14", "310611b6528344cfb645862373be14dd10.06.2022235833" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsStarted",
                table: "AppUserExam");

            migrationBuilder.DropColumn(
                name: "UserStartDate",
                table: "AppUserExam");

            migrationBuilder.AddColumn<bool>(
                name: "IsStarted",
                table: "Exams",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UserStartDate",
                table: "Exams",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "154aee5a667148adaeea896b978cfbc8", "d3e387b86715cec315db55595a44c986b3ea303c6802b78e9f0f331208b039deec4d8797248bcea37c6a0d04e4733de0d5034c6329b9940094bb6fa8c98c86f3", "42a678e17b9549fab24d83c4d53ff65426.05.2022222306" });
        }
    }
}
