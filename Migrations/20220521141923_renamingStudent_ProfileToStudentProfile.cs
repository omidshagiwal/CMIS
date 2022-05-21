using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CMIS.Migrations
{
    public partial class renamingStudent_ProfileToStudentProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LookUp_Class",
                columns: table => new
                {
                    ClassID = table.Column<int>(nullable: false),
                    ClassName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUp_Class", x => x.ClassID);
                });

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
                name: "LookUp_Province",
                columns: table => new
                {
                    ProvinceID = table.Column<int>(nullable: false),
                    ProvinceNameDari = table.Column<string>(nullable: true),
                    ProvinceNameEng = table.Column<string>(nullable: true),
                    ProvinceNamePashto = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUp_Province", x => x.ProvinceID);
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LookUp_District",
                columns: table => new
                {
                    DistrictID = table.Column<int>(nullable: false),
                    DistrictName = table.Column<string>(nullable: true),
                    DistrictNameEnglish = table.Column<string>(nullable: true),
                    DistrictIdNew = table.Column<int>(nullable: true),
                    ProvinceID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUp_District", x => x.DistrictID);
                    table.ForeignKey(
                        name: "FK_LookUp_District_LookUp_Province_ProvinceID",
                        column: x => x.ProvinceID,
                        principalTable: "LookUp_Province",
                        principalColumn: "ProvinceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentsProfile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    FatherName = table.Column<string>(nullable: false),
                    NameEnglish = table.Column<string>(nullable: false),
                    FatherNameEnglish = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<long>(nullable: false),
                    Gender = table.Column<bool>(nullable: false),
                    Picture = table.Column<string>(nullable: true),
                    ProvinceID = table.Column<int>(nullable: false),
                    Lookup_ProvinceProvinceID = table.Column<int>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    GrandFatherName = table.Column<string>(nullable: false),
                    NID = table.Column<string>(nullable: false),
                    ClassEnrollment = table.Column<int>(nullable: false),
                    Entry_Type = table.Column<string>(nullable: true),
                    ThreeYearMarks = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentsProfile_LookUp_Province_Lookup_ProvinceProvinceID",
                        column: x => x.Lookup_ProvinceProvinceID,
                        principalTable: "LookUp_Province",
                        principalColumn: "ProvinceID",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateTable(
                name: "LookUp_School",
                columns: table => new
                {
                    SchoolID = table.Column<int>(nullable: false),
                    SchoolNameDari = table.Column<string>(nullable: true),
                    SchoolNameEnglish = table.Column<string>(nullable: true),
                    SchoolNamePashto = table.Column<string>(nullable: true),
                    SchoolNamePrevious = table.Column<string>(nullable: true),
                    CurrentStageId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    EntryUserId = table.Column<string>(nullable: true),
                    EntryDate = table.Column<DateTime>(nullable: false),
                    DistrictID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUp_School", x => x.SchoolID);
                    table.ForeignKey(
                        name: "FK_LookUp_School_LookUp_District_DistrictID",
                        column: x => x.DistrictID,
                        principalTable: "LookUp_District",
                        principalColumn: "DistrictID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student_Class_Info",
                columns: table => new
                {
                    StudentID = table.Column<int>(nullable: false),
                    ClassID = table.Column<int>(nullable: false),
                    GraduationYear = table.Column<int>(nullable: false),
                    AdmissionID = table.Column<int>(nullable: false),
                    SchoolID = table.Column<long>(nullable: false),
                    SectionID = table.Column<int>(nullable: false),
                    Student_Status_ID = table.Column<int>(nullable: false),
                    EnrollmentStatusID = table.Column<int>(nullable: false),
                    DocumentOrderNo = table.Column<int>(nullable: true),
                    StudentOrderNo = table.Column<int>(nullable: true),
                    IsVerified = table.Column<bool>(nullable: true),
                    VerifiedBy = table.Column<Guid>(nullable: true),
                    VerifiedDate = table.Column<DateTime>(nullable: true),
                    InsertedDate = table.Column<DateTime>(nullable: true),
                    SpcialistName = table.Column<string>(nullable: true),
                    ClassPosition = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    InsertedBy = table.Column<Guid>(nullable: true),
                    IsCenterVerified = table.Column<bool>(nullable: true),
                    CenterVerified_By = table.Column<Guid>(nullable: true),
                    CenterVerified_Date = table.Column<DateTime>(nullable: true),
                    CenterSpecialistName = table.Column<string>(nullable: true),
                    PromotedBy = table.Column<Guid>(nullable: true),
                    PromotionDate = table.Column<DateTime>(nullable: true),
                    IsRecordUpdated = table.Column<bool>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdationDate = table.Column<DateTime>(nullable: true),
                    PromotedYear = table.Column<int>(nullable: true),
                    IsFinalVerified = table.Column<bool>(nullable: true),
                    Student_ProfileId = table.Column<int>(nullable: true),
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
                        name: "FK_Student_Class_Info_StudentsProfile_Student_ProfileId",
                        column: x => x.Student_ProfileId,
                        principalTable: "StudentsProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LookUp_ClassSubject_LookUp_ClassClassID",
                table: "LookUp_ClassSubject",
                column: "LookUp_ClassClassID");

            migrationBuilder.CreateIndex(
                name: "IX_LookUp_ClassSubject_Student_SubjectSubjectID",
                table: "LookUp_ClassSubject",
                column: "Student_SubjectSubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_LookUp_District_ProvinceID",
                table: "LookUp_District",
                column: "ProvinceID");

            migrationBuilder.CreateIndex(
                name: "IX_LookUp_School_DistrictID",
                table: "LookUp_School",
                column: "DistrictID");

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

            migrationBuilder.CreateIndex(
                name: "IX_Student_Class_Info_Student_ProfileId",
                table: "Student_Class_Info",
                column: "Student_ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsProfile_Lookup_ProvinceProvinceID",
                table: "StudentsProfile",
                column: "Lookup_ProvinceProvinceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "LookUp_ClassSubject");

            migrationBuilder.DropTable(
                name: "LookUp_Student_Status");

            migrationBuilder.DropTable(
                name: "LookUp_Subject");

            migrationBuilder.DropTable(
                name: "LookUp_Year");

            migrationBuilder.DropTable(
                name: "Student_Class_Info");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Student_Subject");

            migrationBuilder.DropTable(
                name: "LookUp_Class");

            migrationBuilder.DropTable(
                name: "LookUp_School");

            migrationBuilder.DropTable(
                name: "LookUp_Section");

            migrationBuilder.DropTable(
                name: "Lookup_Enrollment_Status");

            migrationBuilder.DropTable(
                name: "StudentsProfile");

            migrationBuilder.DropTable(
                name: "LookUp_District");

            migrationBuilder.DropTable(
                name: "LookUp_Province");
        }
    }
}
