using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiveExamSystemWebApp.DataAccess.Migrations
{
    public partial class v10_QuestionFileCodeNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FileCode",
                table: "Questions",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "f4787c2e708b448eb8809712611e3f2e", "78831fdb783982fb9b19811b38bc67ea5356ff7506fff358793201570f721b52b7b26f92050010361c926643ad5574d47c81438d7378ea635302805e39adb3cf", "72263e79cd4a47669e1c9b48a1bdf10525.06.2022185857" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "FileCode",
                keyValue: null,
                column: "FileCode",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "FileCode",
                table: "Questions",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "49341c6173044c218348575110fabbd5", "71fd8cb2d8cb915d5b1428d49dd3a51e67a3793b41b4ece5f13e3ac15bb6aab50c31bb1b47b0827cab5ac432e2b1d66cdf54a63f292761a825a54f124d026573", "04c33db6c0f6456abbde9a7d59c4b06822.06.2022235047" });
        }
    }
}
