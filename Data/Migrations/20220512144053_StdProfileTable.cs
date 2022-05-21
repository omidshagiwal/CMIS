using Microsoft.EntityFrameworkCore.Migrations;

namespace CMIS.Data.Migrations
{
    public partial class StdProfileTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student_Profile",
                columns: table => new
                {
                    StudentID = table.Column<int>(nullable: false),
                    StudentName = table.Column<string>(nullable: true),
                    StudentFatherName = table.Column<string>(nullable: true),
                    StudentEngName = table.Column<string>(nullable: true),
                    StudentFatherEngName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<long>(nullable: false),
                    StudentGender = table.Column<bool>(nullable: false),
                    StudentPicPath = table.Column<string>(nullable: true),
                    ProvinceID = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    StudentGrandFatherName = table.Column<string>(nullable: true),
                    TazkiraNumber = table.Column<string>(nullable: true),
                    ClassEnrollment = table.Column<int>(nullable: false),
                    Entry_Type = table.Column<string>(nullable: true),
                    ThreeYearMarks = table.Column<int>(nullable: false),
                    Lookup_ProvinceProvinceID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student_Profile", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_Student_Profile_LookUp_Province_Lookup_ProvinceProvinceID",
                        column: x => x.Lookup_ProvinceProvinceID,
                        principalTable: "LookUp_Province",
                        principalColumn: "ProvinceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_Profile_Lookup_ProvinceProvinceID",
                table: "Student_Profile",
                column: "Lookup_ProvinceProvinceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student_Profile");
        }
    }
}
