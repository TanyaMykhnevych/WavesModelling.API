using Microsoft.EntityFrameworkCore.Migrations;

namespace Waves.Domain.Migrations
{
    public partial class ChangedFieldsOptionsOscillators : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "N",
                table: "Seas");

            migrationBuilder.DropColumn(
                name: "Omega",
                table: "Oscillators");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "N",
                table: "Seas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Omega",
                table: "Oscillators",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
