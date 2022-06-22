using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiveExamSystemWebApp.DataAccess.Migrations
{
    public partial class v7_QuestionCorrectAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CorrectAnswerIndex",
                table: "Questions");

            migrationBuilder.AddColumn<string>(
                name: "CorrectAnswer",
                table: "Questions",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "b193b730d92f475a8e75bc96e83cbe45", "921f934a2d53f94ca5b8d4e5c6fa2fcd2bffcb6b11bea82df733f39b54a1b75fe32446a1c4ec5e3f23c6da05f4c0d5dc2aeefcab50fc78ae569f341f68a6d711", "a3a18fcb1c8e44648fd5472c7b9b6af322.06.2022231518" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CorrectAnswer",
                table: "Questions");

            migrationBuilder.AddColumn<int>(
                name: "CorrectAnswerIndex",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "14211e70040f4add8d8a15422816ec88", "85854f07f3e37651572a900da3fef3e1c0dd8c1e418c80b0704b86b1acfd2cd50115a6e9532bd03208626d1ae30ce68cc7effde7319d17db19bd0d67011e0e42", "b340fdfaaa254d14b1b8b42c982f96ae15.06.2022233710" });
        }
    }
}
