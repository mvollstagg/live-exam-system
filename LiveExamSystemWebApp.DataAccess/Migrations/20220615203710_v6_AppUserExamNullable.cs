using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiveExamSystemWebApp.DataAccess.Migrations
{
    public partial class v6_AppUserExamNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "WrongAnswer",
                table: "AppUserExam",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UserStartDate",
                table: "AppUserExam",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<int>(
                name: "Score",
                table: "AppUserExam",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RightAnswer",
                table: "AppUserExam",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "14211e70040f4add8d8a15422816ec88", "85854f07f3e37651572a900da3fef3e1c0dd8c1e418c80b0704b86b1acfd2cd50115a6e9532bd03208626d1ae30ce68cc7effde7319d17db19bd0d67011e0e42", "b340fdfaaa254d14b1b8b42c982f96ae15.06.2022233710" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "WrongAnswer",
                table: "AppUserExam",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UserStartDate",
                table: "AppUserExam",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Score",
                table: "AppUserExam",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RightAnswer",
                table: "AppUserExam",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "485ce0f6be26426db799d59a1d2f64a4", "662fa573b1974fe0e5623763e6210a932bbfe85a1a083953f89d020a2617c116b07f861e800babd73d2c77c0977b0606cb60ee36f7eadc3ea8a1c91ea5e91d14", "310611b6528344cfb645862373be14dd10.06.2022235833" });
        }
    }
}
