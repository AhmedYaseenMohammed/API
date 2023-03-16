using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APITest.Migrations
{
    public partial class aasa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imagePath",
                table: "UploadFile");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "UploadFile",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "UploadFile",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "imagePath",
                table: "UploadFile",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
