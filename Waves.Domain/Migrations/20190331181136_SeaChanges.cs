using Microsoft.EntityFrameworkCore.Migrations;

namespace Waves.Domain.Migrations
{
    public partial class SeaChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Seas",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Projects",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Oscillators",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<double>(
                name: "W",
                table: "Options",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Options",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Isles",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColumnTo",
                table: "Isles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Isles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "RowTo",
                table: "Isles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AppRoleFeatures",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Seas");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Oscillators");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "ColumnTo",
                table: "Isles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Isles");

            migrationBuilder.DropColumn(
                name: "RowTo",
                table: "Isles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AppRoleFeatures");

            migrationBuilder.AlterColumn<int>(
                name: "W",
                table: "Options",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Isles",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
