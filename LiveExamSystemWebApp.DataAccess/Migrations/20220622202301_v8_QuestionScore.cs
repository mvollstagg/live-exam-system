using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiveExamSystemWebApp.DataAccess.Migrations
{
    public partial class v8_QuestionScore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Score",
                table: "AppUserExam",
                type: "double",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "a767c542283445a8b7e874fbb7d8072d", "e99a6a4ca422d046e55106c427446b889cc8e065c4fa253d3b1aa6fd9efa21197f4e1769b84b6abe244eab5a1b5125322698886b8660f02b2a08e39bc0dffc53", "fc1804a50f624c4faffccc5f57563df222.06.2022232300" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Score",
                table: "AppUserExam",
                type: "int",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "b193b730d92f475a8e75bc96e83cbe45", "921f934a2d53f94ca5b8d4e5c6fa2fcd2bffcb6b11bea82df733f39b54a1b75fe32446a1c4ec5e3f23c6da05f4c0d5dc2aeefcab50fc78ae569f341f68a6d711", "a3a18fcb1c8e44648fd5472c7b9b6af322.06.2022231518" });
        }
    }
}
