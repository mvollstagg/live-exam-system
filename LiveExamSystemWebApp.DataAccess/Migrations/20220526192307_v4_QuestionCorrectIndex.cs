using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiveExamSystemWebApp.DataAccess.Migrations
{
    public partial class v4_QuestionCorrectIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCorrect",
                table: "Answers");

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
                values: new object[] { "154aee5a667148adaeea896b978cfbc8", "d3e387b86715cec315db55595a44c986b3ea303c6802b78e9f0f331208b039deec4d8797248bcea37c6a0d04e4733de0d5034c6329b9940094bb6fa8c98c86f3", "42a678e17b9549fab24d83c4d53ff65426.05.2022222306" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CorrectAnswerIndex",
                table: "Questions");

            migrationBuilder.AddColumn<bool>(
                name: "IsCorrect",
                table: "Answers",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "39b4c61a7d0f4be59e517c0d7dd2422a", "095a8498ec053122d79576e14906c23f9a4f74e82e8de7c52cbfc610f0e7471b118b95d93dc674dcb3293d51303fe52ae7c276af98f8083ccc57bac7c48e96d6", "667f1bf1d9e34094922239b0678dfcf323.05.2022225656" });
        }
    }
}
