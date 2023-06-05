using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NET___fiorello_backend.Migrations
{
    public partial class InsertNameColumnToSliderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Sliders");
        }
    }
}
