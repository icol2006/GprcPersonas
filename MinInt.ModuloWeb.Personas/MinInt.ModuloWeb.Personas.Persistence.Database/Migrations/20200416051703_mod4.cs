using Microsoft.EntityFrameworkCore.Migrations;

namespace MinInt.ModuloWeb.Personas.Persistence.Database.Migrations
{
    public partial class mod4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ID_EVALUADOR",
                table: "JEFATURA");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ID_EVALUADOR",
                table: "JEFATURA",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "JEFATURA",
                keyColumn: "ID_JEFATURA",
                keyValue: 1,
                column: "ID_EVALUADOR",
                value: 1);
        }
    }
}
