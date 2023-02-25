using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiveExamSystemWebApp.DataAccess.Migrations
{
    public partial class v11_AppUserExamIsEnd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsEnd",
                table: "AppUserExam",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "180dec2cf3a64b6eb3a87c51600035ff", "a70ebc46dd65777ece6620dddb4cde2aa68c83352e54611285206dbc59189ff2aef56892702fcea6e1d63bd58837742e9021832307b77a623e5211e87981230d", "647055b9da774bcbadd3448c2aba0bc026.06.2022224817" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEnd",
                table: "AppUserExam");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "f4787c2e708b448eb8809712611e3f2e", "78831fdb783982fb9b19811b38bc67ea5356ff7506fff358793201570f721b52b7b26f92050010361c926643ad5574d47c81438d7378ea635302805e39adb3cf", "72263e79cd4a47669e1c9b48a1bdf10525.06.2022185857" });
        }
    }
}
