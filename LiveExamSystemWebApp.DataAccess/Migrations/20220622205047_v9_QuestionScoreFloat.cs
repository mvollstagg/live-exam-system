using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiveExamSystemWebApp.DataAccess.Migrations
{
    public partial class v9_QuestionScoreFloat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Score",
                table: "AppUserExam",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "49341c6173044c218348575110fabbd5", "71fd8cb2d8cb915d5b1428d49dd3a51e67a3793b41b4ece5f13e3ac15bb6aab50c31bb1b47b0827cab5ac432e2b1d66cdf54a63f292761a825a54f124d026573", "04c33db6c0f6456abbde9a7d59c4b06822.06.2022235047" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Score",
                table: "AppUserExam",
                type: "double",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "a767c542283445a8b7e874fbb7d8072d", "e99a6a4ca422d046e55106c427446b889cc8e065c4fa253d3b1aa6fd9efa21197f4e1769b84b6abe244eab5a1b5125322698886b8660f02b2a08e39bc0dffc53", "fc1804a50f624c4faffccc5f57563df222.06.2022232300" });
        }
    }
}
