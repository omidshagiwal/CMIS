using Microsoft.EntityFrameworkCore.Migrations;

namespace CMIS.Data.Migrations
{
    public partial class biuldLookupTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LookUp_District_LookUp_Province_ProvinceId",
                table: "LookUp_District");

            migrationBuilder.DropTable(
                name: "EnrollmentStatus");

            migrationBuilder.DropTable(
                name: "Section");

            migrationBuilder.DropTable(
                name: "StudentClassSubject");

            migrationBuilder.DropTable(
                name: "Year");

            migrationBuilder.DropTable(
                name: "LookUp_StudentSubject");

            migrationBuilder.DropColumn(
                name: "SchoolName_Previous",
                table: "LookUp_School");

            migrationBuilder.RenameColumn(
                name: "SchoolId",
                table: "LookUp_School",
                newName: "SchoolID");

            migrationBuilder.RenameColumn(
                name: "ProvinceId",
                table: "LookUp_Province",
                newName: "ProvinceID");

            migrationBuilder.RenameColumn(
                name: "ProvinceId",
                table: "LookUp_District",
                newName: "ProvinceID");

            migrationBuilder.RenameColumn(
                name: "DistrictId",
                table: "LookUp_District",
                newName: "DistrictID");

            migrationBuilder.RenameIndex(
                name: "IX_LookUp_District_ProvinceId",
                table: "LookUp_District",
                newName: "IX_LookUp_District_ProvinceID");

            migrationBuilder.AddColumn<string>(
                name: "SchoolNamePrevious",
                table: "LookUp_School",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Lookup_Enrollment_Status",
                columns: table => new
                {
                    EnrollmentStatusID = table.Column<int>(nullable: false),
                    Condidtion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lookup_Enrollment_Status", x => x.EnrollmentStatusID);
                });

            migrationBuilder.CreateTable(
                name: "LookUp_Section",
                columns: table => new
                {
                    SectionID = table.Column<int>(nullable: false),
                    SectionNumber = table.Column<string>(nullable: true),
                    SectionEnglish = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUp_Section", x => x.SectionID);
                });

            migrationBuilder.CreateTable(
                name: "LookUp_Student_Status",
                columns: table => new
                {
                    StatusID = table.Column<int>(nullable: false),
                    StatusEnglishName = table.Column<string>(nullable: true),
                    StatusPashtoName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUp_Student_Status", x => x.StatusID);
                });

            migrationBuilder.CreateTable(
                name: "LookUp_Subject",
                columns: table => new
                {
                    StudentSubjectID = table.Column<int>(nullable: false),
                    SubjectName = table.Column<string>(nullable: true),
                    SubjectNameEnglish = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    CertficateOrderNo = table.Column<int>(nullable: true),
                    ViewOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUp_Subject", x => x.StudentSubjectID);
                });

            migrationBuilder.CreateTable(
                name: "LookUp_Year",
                columns: table => new
                {
                    YearID = table.Column<int>(nullable: false),
                    YearValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUp_Year", x => x.YearID);
                });

            migrationBuilder.CreateTable(
                name: "Student_Subject",
                columns: table => new
                {
                    SubjectID = table.Column<int>(nullable: false),
                    SubjectName = table.Column<string>(nullable: true),
                    SubjectEngName = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    CertificateOrderNo = table.Column<int>(nullable: false),
                    ViewOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student_Subject", x => x.SubjectID);
                });

            migrationBuilder.CreateTable(
                name: "LookUp_ClassSubject",
                columns: table => new
                {
                    ClassSubjectID = table.Column<int>(nullable: false),
                    ClassID = table.Column<int>(nullable: false),
                    SubjectID = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    SortNo = table.Column<int>(nullable: false),
                    LookUp_ClassClassID = table.Column<int>(nullable: true),
                    Student_SubjectSubjectID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUp_ClassSubject", x => x.ClassSubjectID);
                    table.ForeignKey(
                        name: "FK_LookUp_ClassSubject_LookUp_Class_LookUp_ClassClassID",
                        column: x => x.LookUp_ClassClassID,
                        principalTable: "LookUp_Class",
                        principalColumn: "ClassID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LookUp_ClassSubject_Student_Subject_Student_SubjectSubjectID",
                        column: x => x.Student_SubjectSubjectID,
                        principalTable: "Student_Subject",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LookUp_ClassSubject_LookUp_ClassClassID",
                table: "LookUp_ClassSubject",
                column: "LookUp_ClassClassID");

            migrationBuilder.CreateIndex(
                name: "IX_LookUp_ClassSubject_Student_SubjectSubjectID",
                table: "LookUp_ClassSubject",
                column: "Student_SubjectSubjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_LookUp_District_LookUp_Province_ProvinceID",
                table: "LookUp_District",
                column: "ProvinceID",
                principalTable: "LookUp_Province",
                principalColumn: "ProvinceID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LookUp_District_LookUp_Province_ProvinceID",
                table: "LookUp_District");

            migrationBuilder.DropTable(
                name: "LookUp_ClassSubject");

            migrationBuilder.DropTable(
                name: "Lookup_Enrollment_Status");

            migrationBuilder.DropTable(
                name: "LookUp_Section");

            migrationBuilder.DropTable(
                name: "LookUp_Student_Status");

            migrationBuilder.DropTable(
                name: "LookUp_Subject");

            migrationBuilder.DropTable(
                name: "LookUp_Year");

            migrationBuilder.DropTable(
                name: "Student_Subject");

            migrationBuilder.DropColumn(
                name: "SchoolNamePrevious",
                table: "LookUp_School");

            migrationBuilder.RenameColumn(
                name: "SchoolID",
                table: "LookUp_School",
                newName: "SchoolId");

            migrationBuilder.RenameColumn(
                name: "ProvinceID",
                table: "LookUp_Province",
                newName: "ProvinceId");

            migrationBuilder.RenameColumn(
                name: "ProvinceID",
                table: "LookUp_District",
                newName: "ProvinceId");

            migrationBuilder.RenameColumn(
                name: "DistrictID",
                table: "LookUp_District",
                newName: "DistrictId");

            migrationBuilder.RenameIndex(
                name: "IX_LookUp_District_ProvinceID",
                table: "LookUp_District",
                newName: "IX_LookUp_District_ProvinceId");

            migrationBuilder.AddColumn<string>(
                name: "SchoolName_Previous",
                table: "LookUp_School",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EnrollmentStatus",
                columns: table => new
                {
                    EnrollmentStatusID = table.Column<int>(type: "int", nullable: false),
                    Condidtion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrollmentStatus", x => x.EnrollmentStatusID);
                });

            migrationBuilder.CreateTable(
                name: "LookUp_StudentSubject",
                columns: table => new
                {
                    SubjectID = table.Column<int>(type: "int", nullable: false),
                    CertficateOrderNo = table.Column<int>(type: "int", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectNameEnglish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ViewOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUp_StudentSubject", x => x.SubjectID);
                });

            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    SectionID = table.Column<int>(type: "int", nullable: false),
                    SectionEnglish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SectionNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section", x => x.SectionID);
                });

            migrationBuilder.CreateTable(
                name: "Year",
                columns: table => new
                {
                    YearID = table.Column<int>(type: "int", nullable: false),
                    YearValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Year", x => x.YearID);
                });

            migrationBuilder.CreateTable(
                name: "StudentClassSubject",
                columns: table => new
                {
                    ClassSubjectID = table.Column<int>(type: "int", nullable: false),
                    ClassID = table.Column<int>(type: "int", nullable: false),
                    LookUp_ClassClassID = table.Column<int>(type: "int", nullable: true),
                    LookUp_StudentSubjectSubjectID = table.Column<int>(type: "int", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SortNo = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    SubjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentClassSubject", x => x.ClassSubjectID);
                    table.ForeignKey(
                        name: "FK_StudentClassSubject_LookUp_Class_LookUp_ClassClassID",
                        column: x => x.LookUp_ClassClassID,
                        principalTable: "LookUp_Class",
                        principalColumn: "ClassID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentClassSubject_LookUp_StudentSubject_LookUp_StudentSubjectSubjectID",
                        column: x => x.LookUp_StudentSubjectSubjectID,
                        principalTable: "LookUp_StudentSubject",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentClassSubject_LookUp_ClassClassID",
                table: "StudentClassSubject",
                column: "LookUp_ClassClassID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClassSubject_LookUp_StudentSubjectSubjectID",
                table: "StudentClassSubject",
                column: "LookUp_StudentSubjectSubjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_LookUp_District_LookUp_Province_ProvinceId",
                table: "LookUp_District",
                column: "ProvinceId",
                principalTable: "LookUp_Province",
                principalColumn: "ProvinceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
