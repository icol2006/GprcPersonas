using Microsoft.EntityFrameworkCore.Migrations;

namespace MinInt.ModuloWeb.Personas.Persistence.Database.Migrations
{
    public partial class mod1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CENTRO_COSTO",
                table: "PERSONAS",
                type: "varchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "USUARIO_WINDOWS",
                table: "PERSONAS",
                type: "varchar(15)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CENTRO_COSTO",
                table: "PERSONAS");

            migrationBuilder.DropColumn(
                name: "USUARIO_WINDOWS",
                table: "PERSONAS");
        }
    }
}
