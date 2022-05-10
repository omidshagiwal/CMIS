using Microsoft.EntityFrameworkCore.Migrations;

namespace CMIS.Data.Migrations
{
    public partial class model_studentclassSubject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentClassSubject",
                columns: table => new
                {
                    ClassSubjectID = table.Column<int>(nullable: false),
                    ClassID = table.Column<int>(nullable: false),
                    LookUp_ClassClassID = table.Column<int>(nullable: true),
                    SubjectID = table.Column<int>(nullable: false),
                    LookUp_StudentSubjectSubjectID = table.Column<int>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    SortNo = table.Column<int>(nullable: false)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentClassSubject");
        }
    }
}
