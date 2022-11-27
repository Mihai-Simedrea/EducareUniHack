using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducareBE.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExerciseId",
                table: "BlobContents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "SubjectsAddedBy",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "SubjectsAddedBy",
                keyColumn: "Id",
                keyValue: 7,
                column: "UserId",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "BlobContents");

            migrationBuilder.UpdateData(
                table: "SubjectsAddedBy",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SubjectsAddedBy",
                keyColumn: "Id",
                keyValue: 7,
                column: "UserId",
                value: 2);
        }
    }
}
