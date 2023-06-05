using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NET___fiorello_backend.Migrations
{
    public partial class AddDColumnToSliderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Sliders");
        }
    }
}
