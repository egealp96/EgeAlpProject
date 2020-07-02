using Microsoft.EntityFrameworkCore.Migrations;

namespace EgeAlpProject.Migrations
{
    public partial class rw : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_VisitedCars_CarId",
                table: "VisitedCars",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_VisitedCars_Cars_CarId",
                table: "VisitedCars",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VisitedCars_Cars_CarId",
                table: "VisitedCars");

            migrationBuilder.DropIndex(
                name: "IX_VisitedCars_CarId",
                table: "VisitedCars");
        }
    }
}
