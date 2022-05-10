using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CMIS.Data.Migrations
{
    public partial class SCHdisProTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Province",
                columns: table => new
                {
                    ProvinceId = table.Column<int>(nullable: false),
                    ProvinceNameDari = table.Column<string>(nullable: true),
                    ProvinceNameEng = table.Column<string>(nullable: true),
                    ProvinceNamePashto = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.ProvinceId);
                });

            migrationBuilder.CreateTable(
                name: "District",
                columns: table => new
                {
                    DistrictId = table.Column<int>(nullable: false),
                    DistrictName = table.Column<string>(nullable: true),
                    ProvinceId = table.Column<int>(nullable: false),
                    DistrictNameEnglish = table.Column<string>(nullable: true),
                    DistrictIdNew = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.DistrictId);
                    table.ForeignKey(
                        name: "FK_District_Province_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Province",
                        principalColumn: "ProvinceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "School",
                columns: table => new
                {
                    SchoolId = table.Column<int>(nullable: false),
                    SchoolNameDari = table.Column<string>(nullable: true),
                    SchoolNameEnglish = table.Column<string>(nullable: true),
                    SchoolNamePashto = table.Column<string>(nullable: true),
                    SchoolName_Previous = table.Column<string>(nullable: true),
                    DistrictId = table.Column<int>(nullable: false),
                    CurrentStageId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    EntryUserId = table.Column<string>(nullable: true),
                    EntryDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School", x => x.SchoolId);
                    table.ForeignKey(
                        name: "FK_School_District_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "District",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_District_ProvinceId",
                table: "District",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_School_DistrictId",
                table: "School",
                column: "DistrictId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "School");

            migrationBuilder.DropTable(
                name: "District");

            migrationBuilder.DropTable(
                name: "Province");
        }
    }
}
