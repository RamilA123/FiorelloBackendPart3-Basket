using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NET___fiorello_backend.Migrations
{
    public partial class CreateStudentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experts_Positions_PositionId",
                table: "Experts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Experts",
                table: "Experts");

            migrationBuilder.RenameTable(
                name: "Experts",
                newName: "Experts");

            migrationBuilder.RenameIndex(
                name: "IX_Experts_PositionId",
                table: "Experts",
                newName: "IX_Experts_PositionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Experts",
                table: "Experts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "CreatedDate", "FullName", "SoftDelete" },
                values: new object[] { 1, 26, new DateTime(2023, 5, 29, 17, 44, 30, 216, DateTimeKind.Local).AddTicks(6023), "Ramil Allahverdiyev", false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "CreatedDate", "FullName", "SoftDelete" },
                values: new object[] { 2, 15, new DateTime(2023, 5, 29, 17, 44, 30, 216, DateTimeKind.Local).AddTicks(6035), "Selim Agamaliyev", false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "CreatedDate", "FullName", "SoftDelete" },
                values: new object[] { 3, 19, new DateTime(2023, 5, 29, 17, 44, 30, 216, DateTimeKind.Local).AddTicks(6035), "Yunis Balakisiyev", false });

            migrationBuilder.AddForeignKey(
                name: "FK_Experts_Positions_PositionId",
                table: "Experts",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experts_Positions_PositionId",
                table: "Experts");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Experts",
                table: "Experts");

            migrationBuilder.RenameTable(
                name: "Experts",
                newName: "customers");

            migrationBuilder.RenameIndex(
                name: "IX_Experts_PositionId",
                table: "customers",
                newName: "IX_customers_PositionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_customers",
                table: "customers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_customers_Positions_PositionId",
                table: "customers",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
