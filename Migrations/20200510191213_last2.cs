using Microsoft.EntityFrameworkCore.Migrations;

namespace EgeAlpProject.Migrations
{
    public partial class last2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarBrandImage_CarBrands_CarBrandId",
                table: "CarBrandImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarBrandImage",
                table: "CarBrandImage");

            migrationBuilder.RenameTable(
                name: "CarBrandImage",
                newName: "CarBrandImages");

            migrationBuilder.RenameIndex(
                name: "IX_CarBrandImage_CarBrandId",
                table: "CarBrandImages",
                newName: "IX_CarBrandImages_CarBrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarBrandImages",
                table: "CarBrandImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarBrandImages_CarBrands_CarBrandId",
                table: "CarBrandImages",
                column: "CarBrandId",
                principalTable: "CarBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarBrandImages_CarBrands_CarBrandId",
                table: "CarBrandImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarBrandImages",
                table: "CarBrandImages");

            migrationBuilder.RenameTable(
                name: "CarBrandImages",
                newName: "CarBrandImage");

            migrationBuilder.RenameIndex(
                name: "IX_CarBrandImages_CarBrandId",
                table: "CarBrandImage",
                newName: "IX_CarBrandImage_CarBrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarBrandImage",
                table: "CarBrandImage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarBrandImage_CarBrands_CarBrandId",
                table: "CarBrandImage",
                column: "CarBrandId",
                principalTable: "CarBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
