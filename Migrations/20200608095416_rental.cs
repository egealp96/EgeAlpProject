using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EgeAlpProject.Migrations
{
    public partial class rental : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Rentals",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "Rentals",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Rentals");
        }
    }
}
