using Microsoft.EntityFrameworkCore.Migrations;

namespace CMIS.Data.Migrations
{
    public partial class _5tablfromimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnrollmentStatus",
                columns: table => new
                {
                    EnrollmentStatusID = table.Column<int>(nullable: false),
                    Condidtion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrollmentStatus", x => x.EnrollmentStatusID);
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
                name: "LookUp_StudentSubject",
                columns: table => new
                {
                    SubjectID = table.Column<int>(nullable: false),
                    SubjectName = table.Column<string>(nullable: true),
                    SubjectNameEnglish = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CertficateOrderNo = table.Column<int>(nullable: false),
                    ViewOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUp_StudentSubject", x => x.SubjectID);
                });

            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    SectionID = table.Column<int>(nullable: false),
                    SectionNumber = table.Column<string>(nullable: true),
                    SectionEnglish = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section", x => x.SectionID);
                });

            migrationBuilder.CreateTable(
                name: "Year",
                columns: table => new
                {
                    YearID = table.Column<int>(nullable: false),
                    YearValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Year", x => x.YearID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnrollmentStatus");

            migrationBuilder.DropTable(
                name: "LookUp_Class");

            migrationBuilder.DropTable(
                name: "LookUp_StudentSubject");

            migrationBuilder.DropTable(
                name: "Section");

            migrationBuilder.DropTable(
                name: "Year");
        }
    }
}
