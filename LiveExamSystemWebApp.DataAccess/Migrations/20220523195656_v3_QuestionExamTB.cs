using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiveExamSystemWebApp.DataAccess.Migrations
{
    public partial class v3_QuestionExamTB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Exams_ExamId",
                table: "Questions");

            migrationBuilder.AlterColumn<int>(
                name: "ExamId",
                table: "Questions",
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
                values: new object[] { "39b4c61a7d0f4be59e517c0d7dd2422a", "095a8498ec053122d79576e14906c23f9a4f74e82e8de7c52cbfc610f0e7471b118b95d93dc674dcb3293d51303fe52ae7c276af98f8083ccc57bac7c48e96d6", "667f1bf1d9e34094922239b0678dfcf323.05.2022225656" });

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Exams_ExamId",
                table: "Questions",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Exams_ExamId",
                table: "Questions");

            migrationBuilder.AlterColumn<int>(
                name: "ExamId",
                table: "Questions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "02e34509ceeb4d0092567a87b9b071c8", "02513de8d6d98243ecd1c50385ed1eda8f77edb1da8b8ce170f556f0d094fe70f97d18b8e6d033c0f417a1d4587a57e539640c0214460019115a1574e88cdbd6", "16b60bd2bfa142f193a1aa97e7f9d99921.05.2022234327" });

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Exams_ExamId",
                table: "Questions",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id");
        }
    }
}
