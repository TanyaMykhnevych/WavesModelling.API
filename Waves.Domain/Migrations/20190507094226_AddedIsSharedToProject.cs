using Microsoft.EntityFrameworkCore.Migrations;

namespace Waves.Domain.Migrations
{
    public partial class AddedIsSharedToProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsShared",
                table: "Projects",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsShared",
                table: "Projects");
        }
    }
}
