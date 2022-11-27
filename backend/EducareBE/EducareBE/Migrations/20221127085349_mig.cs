using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducareBE.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlobContent_SubjectsAddedBy_SubjectAddedById",
                table: "BlobContent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlobContent",
                table: "BlobContent");

            migrationBuilder.RenameTable(
                name: "BlobContent",
                newName: "BlobContents");

            migrationBuilder.RenameIndex(
                name: "IX_BlobContent_SubjectAddedById",
                table: "BlobContents",
                newName: "IX_BlobContents_SubjectAddedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlobContents",
                table: "BlobContents",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Faculty of Mechanical Engineering");

            migrationBuilder.AddForeignKey(
                name: "FK_BlobContents_SubjectsAddedBy_SubjectAddedById",
                table: "BlobContents",
                column: "SubjectAddedById",
                principalTable: "SubjectsAddedBy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlobContents_SubjectsAddedBy_SubjectAddedById",
                table: "BlobContents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlobContents",
                table: "BlobContents");

            migrationBuilder.RenameTable(
                name: "BlobContents",
                newName: "BlobContent");

            migrationBuilder.RenameIndex(
                name: "IX_BlobContents_SubjectAddedById",
                table: "BlobContent",
                newName: "IX_BlobContent_SubjectAddedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlobContent",
                table: "BlobContent",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Faculty of Mechanical Engineerin");

            migrationBuilder.AddForeignKey(
                name: "FK_BlobContent_SubjectsAddedBy_SubjectAddedById",
                table: "BlobContent",
                column: "SubjectAddedById",
                principalTable: "SubjectsAddedBy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
