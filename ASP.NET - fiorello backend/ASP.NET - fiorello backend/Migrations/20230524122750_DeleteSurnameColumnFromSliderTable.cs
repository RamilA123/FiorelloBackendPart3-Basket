using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NET___fiorello_backend.Migrations
{
    public partial class DeleteSurnameColumnFromSliderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Sliders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
