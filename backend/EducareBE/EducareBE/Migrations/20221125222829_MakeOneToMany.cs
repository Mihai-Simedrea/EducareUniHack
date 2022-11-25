using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducareBE.Migrations
{
    public partial class MakeOneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faculties_Fields_FieldId",
                table: "Faculties");

            migrationBuilder.DropForeignKey(
                name: "FK_Fields_Courses_CourseId",
                table: "Fields");

            migrationBuilder.DropIndex(
                name: "IX_Fields_CourseId",
                table: "Fields");

            migrationBuilder.DropIndex(
                name: "IX_Faculties_FieldId",
                table: "Faculties");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Fields",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FieldId",
                table: "Faculties",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_CourseId",
                table: "Fields",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_FieldId",
                table: "Faculties",
                column: "FieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_Faculties_Fields_FieldId",
                table: "Faculties",
                column: "FieldId",
                principalTable: "Fields",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fields_Courses_CourseId",
                table: "Fields",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faculties_Fields_FieldId",
                table: "Faculties");

            migrationBuilder.DropForeignKey(
                name: "FK_Fields_Courses_CourseId",
                table: "Fields");

            migrationBuilder.DropIndex(
                name: "IX_Fields_CourseId",
                table: "Fields");

            migrationBuilder.DropIndex(
                name: "IX_Faculties_FieldId",
                table: "Faculties");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Fields",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FieldId",
                table: "Faculties",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fields_CourseId",
                table: "Fields",
                column: "CourseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_FieldId",
                table: "Faculties",
                column: "FieldId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Faculties_Fields_FieldId",
                table: "Faculties",
                column: "FieldId",
                principalTable: "Fields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fields_Courses_CourseId",
                table: "Fields",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
