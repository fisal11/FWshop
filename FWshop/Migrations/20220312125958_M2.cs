using Microsoft.EntityFrameworkCore.Migrations;

namespace FWshop.Migrations
{
    public partial class M2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emploee_District_DistrictId",
                table: "Emploee");

            migrationBuilder.AlterColumn<int>(
                name: "DistrictId",
                table: "Emploee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Emploee_District_DistrictId",
                table: "Emploee",
                column: "DistrictId",
                principalTable: "District",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emploee_District_DistrictId",
                table: "Emploee");

            migrationBuilder.AlterColumn<int>(
                name: "DistrictId",
                table: "Emploee",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Emploee_District_DistrictId",
                table: "Emploee",
                column: "DistrictId",
                principalTable: "District",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
