using Microsoft.EntityFrameworkCore.Migrations;

namespace restful_api.Migrations
{
    public partial class FixingTypoinLoginTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pasword",
                table: "Logins");

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "Logins",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password",
                table: "Logins");

            migrationBuilder.AddColumn<string>(
                name: "pasword",
                table: "Logins",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
