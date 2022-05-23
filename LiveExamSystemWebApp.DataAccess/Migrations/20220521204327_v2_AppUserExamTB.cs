using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiveExamSystemWebApp.DataAccess.Migrations
{
    public partial class v2_AppUserExamTB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_AppUsers_AppUserId",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_AppUserId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Exams");

            migrationBuilder.CreateTable(
                name: "AppUserExam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    ExamId = table.Column<int>(type: "int", nullable: false),
                    RightAnswer = table.Column<int>(type: "int", nullable: false),
                    WrongAnswer = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    GuId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserExam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserExam_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserExam_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "02e34509ceeb4d0092567a87b9b071c8", "02513de8d6d98243ecd1c50385ed1eda8f77edb1da8b8ce170f556f0d094fe70f97d18b8e6d033c0f417a1d4587a57e539640c0214460019115a1574e88cdbd6", "16b60bd2bfa142f193a1aa97e7f9d99921.05.2022234327" });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserExam_AppUserId",
                table: "AppUserExam",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserExam_ExamId",
                table: "AppUserExam",
                column: "ExamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserExam");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Exams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "Exams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Exams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "5bd653e533ff48478a80521bf71a2e11", "04f355be9620e9e386bf48c67ad47be836585d0194b2d941f2aad20c23f0a78b6fc94fb1ff08c61dfa29384a2b96a1770ed31318646cea32f6ce369ee468f26f", "67dcf34776514671bde3a49909de8e6116.05.2022210719" });

            migrationBuilder.CreateIndex(
                name: "IX_Exams_AppUserId",
                table: "Exams",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_AppUsers_AppUserId",
                table: "Exams",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
