using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NET___fiorello_backend.Migrations
{
    public partial class AddIsMainColumntoProductImageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMain",
                table: "Images",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMain",
                table: "Images");
        }
    }
}
