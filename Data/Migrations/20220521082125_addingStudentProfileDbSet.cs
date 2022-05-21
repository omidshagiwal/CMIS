using Microsoft.EntityFrameworkCore.Migrations;

namespace CMIS.Data.Migrations
{
    public partial class addingStudentProfileDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentProfiles",
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
                    table.PrimaryKey("PK_StudentProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentProfiles_LookUp_Province_Lookup_ProvinceProvinceID",
                        column: x => x.Lookup_ProvinceProvinceID,
                        principalTable: "LookUp_Province",
                        principalColumn: "ProvinceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentProfiles_Lookup_ProvinceProvinceID",
                table: "StudentProfiles",
                column: "Lookup_ProvinceProvinceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentProfiles");
        }
    }
}
