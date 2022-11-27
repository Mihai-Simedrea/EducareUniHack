using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducareBE.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalSubjects = table.Column<int>(type: "int", nullable: false),
                    TotalExercices = table.Column<int>(type: "int", nullable: false),
                    TotalFields = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniversityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faculties_Universities_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "Universities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniversityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FieldName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacultyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudyYear = table.Column<int>(type: "int", nullable: false),
                    NumberOfLikes = table.Column<int>(type: "int", nullable: false),
                    NumberOfPosts = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacultyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fields_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFavorite = table.Column<bool>(type: "bit", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: true),
                    FieldId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EnrolledCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsFavoirte = table.Column<bool>(type: "bit", nullable: true),
                    IsEnrolled = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrolledCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnrolledCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnrolledCourses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subjects_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubjectsAddedBy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectsAddedBy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectsAddedBy_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubjectsAddedBy_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SubjectAddedById = table.Column<int>(type: "int", nullable: false),
                    LikesCount = table.Column<int>(type: "int", nullable: false),
                    DislikesCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_SubjectsAddedBy_SubjectAddedById",
                        column: x => x.SubjectAddedById,
                        principalTable: "SubjectsAddedBy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "TotalExercices", "TotalFields", "TotalSubjects" },
                values: new object[,]
                {
                    { 1, "Polytechnic University of Timisoara", 0, 0, 0 },
                    { 2, "Vest University of Timisoara", 0, 0, 0 },
                    { 3, "Standford University", 0, 0, 0 },
                    { 5, "Polytechnic University of Bucharest", 0, 0, 0 },
                    { 6, "Polytechnic University of Iasi", 0, 0, 0 },
                    { 7, "Carol Davila University of Medicine", 0, 0, 0 },
                    { 8, "University of Medicine and Pharmacy of Craiova", 0, 0, 0 },
                    { 9, "Lucian Blaga University of Sibiu", 0, 0, 0 },
                    { 10, "Massachusetts Institute of Technology", 0, 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, "jhon.smith@student.upt.ro", "password", "johnny47" },
                    { 2, "makhur.khena@student.upt.ro", "password", "makhur.khena" },
                    { 3, "zaya.del@student.upt.ro", "password", "zayaTheBest" },
                    { 4, "gerdi.ninkhafk@student.upt.ro", "password", "ninkhafk99" },
                    { 5, "rhiannon.bovun@student.upt.ro", "password", "bovun2003" },
                    { 6, "rol.khihrerl@student.upt.ro", "password", "khihrerl007" },
                    { 7, "shepard.hanni@student.upt.ro", "password", "hanni_" },
                    { 8, "buiron.tin@student.mit.us", "password", "tin77" },
                    { 9, "rell.findazrum@student.lca.de", "password", "rell_findar1" },
                    { 10, "xandra.tiang@student.upt.ro", "password", "alexandra" },
                    { 11, "andrew.techel@student.upt.ro", "password", "andreeew" },
                    { 12, "gustavo.del@student.upt.ro", "password", "gustavo412" }
                });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "Id", "Name", "UniversityId" },
                values: new object[,]
                {
                    { 1, "Automation And Computers", 1 },
                    { 2, "Electronics and Telecomunication", 1 },
                    { 3, "Faculty Of Managemen And Transportation ", 1 },
                    { 4, "Faculty of Mechanical Engineerin", 1 },
                    { 5, "Faculty of Finance and Banking", 1 },
                    { 6, "Automation And Computers", 5 },
                    { 7, "Electronics and Telecomunication", 5 },
                    { 8, "Faculty Of Managemen And Transportation ", 5 },
                    { 9, "Faculty of Mechanical Engineerin", 5 },
                    { 10, "Faculty of Finance and Banking", 5 },
                    { 11, "Automation And Computers", 6 },
                    { 12, "Electronics and Telecomunication", 6 },
                    { 13, "Faculty Of Management And Transportation ", 6 },
                    { 14, "Faculty of Mechanical Engineerin", 6 },
                    { 15, "Faculty of Finance and Banking", 6 },
                    { 16, "Faculty Of Mathemathics", 2 },
                    { 17, "Faculty of Biology", 2 },
                    { 18, "Faculty Of Managemen And Transportation ", 2 },
                    { 19, "Faculty of Mechanical Engineerin", 2 },
                    { 20, "Faculty of Finance and Banking", 2 },
                    { 21, "Faculty of General Medicine", 7 },
                    { 22, "Faculty of Dental Medicine", 7 },
                    { 23, "Faculty of Chirurgy", 7 }
                });

            migrationBuilder.InsertData(
                table: "Fields",
                columns: new[] { "Id", "FacultyId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Informatics" },
                    { 2, 1, "Computers and Information Technology" },
                    { 3, 1, "System Engineering" },
                    { 4, 2, "Telecomunications" },
                    { 5, 3, "Transporting Engineering" },
                    { 6, 4, "Management Engineering" },
                    { 7, 5, "Finance" },
                    { 8, 5, "Bussiness" },
                    { 9, 5, "Banking" },
                    { 10, 1, "Informatics" },
                    { 11, 1, "Computers and Information Technology" },
                    { 12, 2, "Informatics" },
                    { 13, 21, "General Medicine" },
                    { 14, 22, "Dental Medicine" },
                    { 15, 23, "Chirurgy" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "FieldId", "IsFavorite", "Name", "Year" },
                values: new object[] { 1, 2, false, "POO", 2 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "FieldId", "IsFavorite", "Name", "Year" },
                values: new object[] { 2, 2, false, "SDA", 2 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "FieldId", "IsFavorite", "Name", "Year" },
                values: new object[] { 3, 2, false, "PTDM", 4 });

            migrationBuilder.InsertData(
                table: "EnrolledCourses",
                columns: new[] { "Id", "CourseId", "IsEnrolled", "IsFavoirte", "UserId" },
                values: new object[,]
                {
                    { 1, 1, true, false, 1 },
                    { 2, 2, true, false, 1 },
                    { 3, 2, false, false, 1 }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "CourseId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Objects and Classes" },
                    { 2, 1, "Polymorphism" },
                    { 3, 1, "Errors" },
                    { 4, 2, "Sorting Algorims" },
                    { 5, 2, "Advanced sorting algoritms" },
                    { 6, 3, "The Oscilloscope" }
                });

            migrationBuilder.InsertData(
                table: "SubjectsAddedBy",
                columns: new[] { "Id", "Name", "SubjectId", "UserId" },
                values: new object[,]
                {
                    { 1, "Definition", 1, 1 },
                    { 2, "Lab Example", 1, 2 },
                    { 3, "Coruse Example", 1, 1 },
                    { 6, "Definition", 2, 2 },
                    { 7, "Lab Example", 2, 2 },
                    { 8, "Coruse Example", 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "DislikesCount", "LikesCount", "SubjectAddedById", "UserId" },
                values: new object[,]
                {
                    { 1, 0, 1, 1, 1 },
                    { 2, 0, 1, 1, 2 },
                    { 3, 0, 1, 1, 3 },
                    { 4, 0, 1, 1, 4 },
                    { 5, 0, 1, 1, 4 },
                    { 6, 0, 1, 1, 5 },
                    { 7, 0, 1, 1, 6 },
                    { 8, 0, 1, 1, 7 },
                    { 9, 0, 1, 1, 8 },
                    { 10, 0, 1, 1, 10 },
                    { 11, 0, 1, 1, 11 },
                    { 12, 1, 0, 1, 12 },
                    { 13, 0, 1, 2, 2 },
                    { 14, 0, 1, 2, 3 },
                    { 15, 0, 1, 2, 4 },
                    { 16, 0, 0, 2, 5 },
                    { 17, 0, 1, 2, 9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_FieldId",
                table: "Courses",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrolledCourses_CourseId",
                table: "EnrolledCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrolledCourses_UserId",
                table: "EnrolledCourses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_UniversityId",
                table: "Faculties",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_FacultyId",
                table: "Fields",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_SubjectAddedById",
                table: "Likes",
                column: "SubjectAddedById");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserId",
                table: "Likes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_CourseId",
                table: "Subjects",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectsAddedBy_SubjectId",
                table: "SubjectsAddedBy",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectsAddedBy_UserId",
                table: "SubjectsAddedBy",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnrolledCourses");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "SubjectsAddedBy");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropTable(
                name: "Universities");
        }
    }
}
