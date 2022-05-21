using Microsoft.EntityFrameworkCore.Migrations;

namespace CMIS.Data.Migrations
{
    public partial class changenameDistrictID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LookUp_School_LookUp_District_DistrictId",
                table: "LookUp_School");

            migrationBuilder.RenameColumn(
                name: "DistrictId",
                table: "LookUp_School",
                newName: "DistrictID");

            migrationBuilder.RenameIndex(
                name: "IX_LookUp_School_DistrictId",
                table: "LookUp_School",
                newName: "IX_LookUp_School_DistrictID");

            migrationBuilder.AddForeignKey(
                name: "FK_LookUp_School_LookUp_District_DistrictID",
                table: "LookUp_School",
                column: "DistrictID",
                principalTable: "LookUp_District",
                principalColumn: "DistrictID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LookUp_School_LookUp_District_DistrictID",
                table: "LookUp_School");

            migrationBuilder.RenameColumn(
                name: "DistrictID",
                table: "LookUp_School",
                newName: "DistrictId");

            migrationBuilder.RenameIndex(
                name: "IX_LookUp_School_DistrictID",
                table: "LookUp_School",
                newName: "IX_LookUp_School_DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_LookUp_School_LookUp_District_DistrictId",
                table: "LookUp_School",
                column: "DistrictId",
                principalTable: "LookUp_District",
                principalColumn: "DistrictID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
