using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendAPI.Migrations
{
    public partial class addData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Parameter1",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Parameter2",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Parameter3",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Parameter4",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Parameter5",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Parameter6",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Parameter7",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Parameter1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Parameter2",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Parameter3",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Parameter4",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Parameter5",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Parameter6",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Parameter7",
                table: "Products");
        }
    }
}
