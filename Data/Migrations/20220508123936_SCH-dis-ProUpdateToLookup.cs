using Microsoft.EntityFrameworkCore.Migrations;

namespace CMIS.Data.Migrations
{
    public partial class SCHdisProUpdateToLookup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_District_Province_ProvinceId",
                table: "District");

            migrationBuilder.DropForeignKey(
                name: "FK_School_District_DistrictId",
                table: "School");

            migrationBuilder.DropPrimaryKey(
                name: "PK_School",
                table: "School");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Province",
                table: "Province");

            migrationBuilder.DropPrimaryKey(
                name: "PK_District",
                table: "District");

            migrationBuilder.RenameTable(
                name: "School",
                newName: "LookUp_School");

            migrationBuilder.RenameTable(
                name: "Province",
                newName: "LookUp_Province");

            migrationBuilder.RenameTable(
                name: "District",
                newName: "LookUp_District");

            migrationBuilder.RenameIndex(
                name: "IX_School_DistrictId",
                table: "LookUp_School",
                newName: "IX_LookUp_School_DistrictId");

            migrationBuilder.RenameIndex(
                name: "IX_District_ProvinceId",
                table: "LookUp_District",
                newName: "IX_LookUp_District_ProvinceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LookUp_School",
                table: "LookUp_School",
                column: "SchoolId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LookUp_Province",
                table: "LookUp_Province",
                column: "ProvinceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LookUp_District",
                table: "LookUp_District",
                column: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_LookUp_District_LookUp_Province_ProvinceId",
                table: "LookUp_District",
                column: "ProvinceId",
                principalTable: "LookUp_Province",
                principalColumn: "ProvinceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LookUp_School_LookUp_District_DistrictId",
                table: "LookUp_School",
                column: "DistrictId",
                principalTable: "LookUp_District",
                principalColumn: "DistrictId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LookUp_District_LookUp_Province_ProvinceId",
                table: "LookUp_District");

            migrationBuilder.DropForeignKey(
                name: "FK_LookUp_School_LookUp_District_DistrictId",
                table: "LookUp_School");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LookUp_School",
                table: "LookUp_School");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LookUp_Province",
                table: "LookUp_Province");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LookUp_District",
                table: "LookUp_District");

            migrationBuilder.RenameTable(
                name: "LookUp_School",
                newName: "School");

            migrationBuilder.RenameTable(
                name: "LookUp_Province",
                newName: "Province");

            migrationBuilder.RenameTable(
                name: "LookUp_District",
                newName: "District");

            migrationBuilder.RenameIndex(
                name: "IX_LookUp_School_DistrictId",
                table: "School",
                newName: "IX_School_DistrictId");

            migrationBuilder.RenameIndex(
                name: "IX_LookUp_District_ProvinceId",
                table: "District",
                newName: "IX_District_ProvinceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_School",
                table: "School",
                column: "SchoolId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Province",
                table: "Province",
                column: "ProvinceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_District",
                table: "District",
                column: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_District_Province_ProvinceId",
                table: "District",
                column: "ProvinceId",
                principalTable: "Province",
                principalColumn: "ProvinceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_School_District_DistrictId",
                table: "School",
                column: "DistrictId",
                principalTable: "District",
                principalColumn: "DistrictId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
