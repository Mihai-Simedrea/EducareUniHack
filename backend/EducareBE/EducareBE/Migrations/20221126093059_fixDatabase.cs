using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducareBE.Migrations
{
    public partial class fixDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Fields_FieldId",
                table: "Subjects");

            migrationBuilder.RenameColumn(
                name: "FieldId",
                table: "Subjects",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Subjects_FieldId",
                table: "Subjects",
                newName: "IX_Subjects_CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Courses_CourseId",
                table: "Subjects",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Courses_CourseId",
                table: "Subjects");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Subjects",
                newName: "FieldId");

            migrationBuilder.RenameIndex(
                name: "IX_Subjects_CourseId",
                table: "Subjects",
                newName: "IX_Subjects_FieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Fields_FieldId",
                table: "Subjects",
                column: "FieldId",
                principalTable: "Fields",
                principalColumn: "Id");
        }
    }
}
