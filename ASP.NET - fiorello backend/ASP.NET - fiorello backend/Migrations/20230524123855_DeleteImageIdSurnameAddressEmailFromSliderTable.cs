using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NET___fiorello_backend.Migrations
{
    public partial class DeleteImageIdSurnameAddressEmailFromSliderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Sliders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Sliders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
