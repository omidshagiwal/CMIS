using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CMIS.Data.Migrations
{
    public partial class StdClassTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student_Class_Info",
                columns: table => new
                {
                    StudentID = table.Column<int>(nullable: false),
                    ClassID = table.Column<int>(nullable: false),
                    GraduationYear = table.Column<int>(nullable: false),
                    SchoolID = table.Column<long>(nullable: false),
                    SectionID = table.Column<int>(nullable: false),
                    EnrollmentStatusID = table.Column<int>(nullable: false),
                    DocumentOrderNo = table.Column<int>(nullable: false),
                    StudentOrderNo = table.Column<int>(nullable: false),
                    IsVerified = table.Column<bool>(nullable: false),
                    VerifiedBy = table.Column<Guid>(nullable: false),
                    VerifiedDate = table.Column<DateTime>(nullable: false),
                    InsertedDate = table.Column<DateTime>(nullable: false),
                    SpcialistName = table.Column<string>(nullable: true),
                    ClassPosition = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    InsertedBy = table.Column<Guid>(nullable: false),
                    IsCenterVerified = table.Column<bool>(nullable: false),
                    CenterVerified_By = table.Column<Guid>(nullable: false),
                    CenterVerified_Date = table.Column<DateTime>(nullable: false),
                    CenterSpecialistName = table.Column<string>(nullable: true),
                    PromotedBy = table.Column<Guid>(nullable: false),
                    PromotionDate = table.Column<DateTime>(nullable: false),
                    IsRecordUpdated = table.Column<bool>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    UpdationDate = table.Column<DateTime>(nullable: false),
                    PromotedYear = table.Column<int>(nullable: false),
                    IsFinalVerified = table.Column<bool>(nullable: false),
                    LookUp_SchoolSchoolID = table.Column<int>(nullable: true),
                    LookUp_SectionSectionID = table.Column<int>(nullable: true),
                    Lookup_Enrollment_StatusEnrollmentStatusID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student_Class_Info", x => new { x.StudentID, x.ClassID, x.GraduationYear });
                    table.ForeignKey(
                        name: "FK_Student_Class_Info_LookUp_Class_ClassID",
                        column: x => x.ClassID,
                        principalTable: "LookUp_Class",
                        principalColumn: "ClassID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_Class_Info_LookUp_School_LookUp_SchoolSchoolID",
                        column: x => x.LookUp_SchoolSchoolID,
                        principalTable: "LookUp_School",
                        principalColumn: "SchoolID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_Class_Info_LookUp_Section_LookUp_SectionSectionID",
                        column: x => x.LookUp_SectionSectionID,
                        principalTable: "LookUp_Section",
                        principalColumn: "SectionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_Class_Info_Lookup_Enrollment_Status_Lookup_Enrollment_StatusEnrollmentStatusID",
                        column: x => x.Lookup_Enrollment_StatusEnrollmentStatusID,
                        principalTable: "Lookup_Enrollment_Status",
                        principalColumn: "EnrollmentStatusID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_Class_Info_Student_Profile_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student_Profile",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_Class_Info_ClassID",
                table: "Student_Class_Info",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Class_Info_LookUp_SchoolSchoolID",
                table: "Student_Class_Info",
                column: "LookUp_SchoolSchoolID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Class_Info_LookUp_SectionSectionID",
                table: "Student_Class_Info",
                column: "LookUp_SectionSectionID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Class_Info_Lookup_Enrollment_StatusEnrollmentStatusID",
                table: "Student_Class_Info",
                column: "Lookup_Enrollment_StatusEnrollmentStatusID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student_Class_Info");
        }
    }
}
