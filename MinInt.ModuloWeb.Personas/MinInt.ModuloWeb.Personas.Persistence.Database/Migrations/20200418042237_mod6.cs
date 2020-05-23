using Microsoft.EntityFrameworkCore.Migrations;

namespace MinInt.ModuloWeb.Personas.Persistence.Database.Migrations
{
    public partial class mod6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ID_SUBROGANTE",
                table: "JEFATURA",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ID_JEFE",
                table: "JEFATURA",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_JEFATURA_ID_JEFE",
                table: "JEFATURA",
                column: "ID_JEFE",
                unique: true,
                filter: "[ID_JEFE] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_JEFATURA_ID_SUBROGANTE",
                table: "JEFATURA",
                column: "ID_SUBROGANTE",
                unique: true,
                filter: "[ID_SUBROGANTE] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_JEFATURA_PERSONAS_ID_JEFE",
                table: "JEFATURA",
                column: "ID_JEFE",
                principalTable: "PERSONAS",
                principalColumn: "ID_PER",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JEFATURA_PERSONAS_ID_SUBROGANTE",
                table: "JEFATURA",
                column: "ID_SUBROGANTE",
                principalTable: "PERSONAS",
                principalColumn: "ID_PER",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JEFATURA_PERSONAS_ID_JEFE",
                table: "JEFATURA");

            migrationBuilder.DropForeignKey(
                name: "FK_JEFATURA_PERSONAS_ID_SUBROGANTE",
                table: "JEFATURA");

            migrationBuilder.DropIndex(
                name: "IX_JEFATURA_ID_JEFE",
                table: "JEFATURA");

            migrationBuilder.DropIndex(
                name: "IX_JEFATURA_ID_SUBROGANTE",
                table: "JEFATURA");

            migrationBuilder.AlterColumn<int>(
                name: "ID_SUBROGANTE",
                table: "JEFATURA",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID_JEFE",
                table: "JEFATURA",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
