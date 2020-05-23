using Microsoft.EntityFrameworkCore.Migrations;

namespace MinInt.ModuloWeb.Personas.Persistence.Database.Migrations
{
    public partial class mod5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PERSONAS_JEFATURA_ID_JEFATURA",
                table: "PERSONAS");

            migrationBuilder.AlterColumn<int>(
                name: "ID_JEFATURA",
                table: "PERSONAS",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PERSONAS_JEFATURA_ID_JEFATURA",
                table: "PERSONAS",
                column: "ID_JEFATURA",
                principalTable: "JEFATURA",
                principalColumn: "ID_JEFATURA",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PERSONAS_JEFATURA_ID_JEFATURA",
                table: "PERSONAS");

            migrationBuilder.AlterColumn<int>(
                name: "ID_JEFATURA",
                table: "PERSONAS",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PERSONAS_JEFATURA_ID_JEFATURA",
                table: "PERSONAS",
                column: "ID_JEFATURA",
                principalTable: "JEFATURA",
                principalColumn: "ID_JEFATURA",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
