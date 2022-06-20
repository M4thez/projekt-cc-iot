using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt.AppService.Migrations
{
    public partial class dateMeasuredMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DateMeasured",
                table: "Measurements",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateMeasured",
                table: "Measurements");
        }
    }
}
