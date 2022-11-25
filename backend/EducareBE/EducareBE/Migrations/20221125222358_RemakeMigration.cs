using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducareBE.Migrations
{
    public partial class RemakeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Universities_Faculties_FacultyId",
                table: "Universities");

            migrationBuilder.DropIndex(
                name: "IX_Universities_FacultyId",
                table: "Universities");

            migrationBuilder.AlterColumn<int>(
                name: "FacultyId",
                table: "Universities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Universities_FacultyId",
                table: "Universities",
                column: "FacultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Universities_Faculties_FacultyId",
                table: "Universities",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Universities_Faculties_FacultyId",
                table: "Universities");

            migrationBuilder.DropIndex(
                name: "IX_Universities_FacultyId",
                table: "Universities");

            migrationBuilder.AlterColumn<int>(
                name: "FacultyId",
                table: "Universities",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Universities_FacultyId",
                table: "Universities",
                column: "FacultyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Universities_Faculties_FacultyId",
                table: "Universities",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
