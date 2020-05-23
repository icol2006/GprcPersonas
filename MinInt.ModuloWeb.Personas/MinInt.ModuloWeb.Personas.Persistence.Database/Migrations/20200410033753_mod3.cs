using Microsoft.EntityFrameworkCore.Migrations;

namespace MinInt.ModuloWeb.Personas.Persistence.Database.Migrations
{
    public partial class mod3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PERSONAS_SISTEMAS_SISTEMAS_SISTEMASID_SISTEMA",
                table: "PERSONAS_SISTEMAS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PERSONAS_SISTEMAS",
                table: "PERSONAS_SISTEMAS");

            migrationBuilder.DropIndex(
                name: "IX_PERSONAS_SISTEMAS_ID_PERMISOS_SISTEMA",
                table: "PERSONAS_SISTEMAS");

            migrationBuilder.DropIndex(
                name: "IX_PERSONAS_SISTEMAS_SISTEMASID_SISTEMA",
                table: "PERSONAS_SISTEMAS");

            migrationBuilder.DropColumn(
                name: "SISTEMASID_SISTEMA",
                table: "PERSONAS_SISTEMAS");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PERSONAS_SISTEMAS",
                table: "PERSONAS_SISTEMAS",
                columns: new[] { "ID_PERMISOS_SISTEMA", "ID_PER", "ID_SISTEMA" });

            migrationBuilder.CreateIndex(
                name: "IX_PERSONAS_SISTEMAS_ID_PER",
                table: "PERSONAS_SISTEMAS",
                column: "ID_PER");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONAS_SISTEMAS_ID_SISTEMA",
                table: "PERSONAS_SISTEMAS",
                column: "ID_SISTEMA");

            migrationBuilder.AddForeignKey(
                name: "FK_PERSONAS_SISTEMAS_SISTEMAS_ID_SISTEMA",
                table: "PERSONAS_SISTEMAS",
                column: "ID_SISTEMA",
                principalTable: "SISTEMAS",
                principalColumn: "ID_SISTEMA",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PERSONAS_SISTEMAS_SISTEMAS_ID_SISTEMA",
                table: "PERSONAS_SISTEMAS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PERSONAS_SISTEMAS",
                table: "PERSONAS_SISTEMAS");

            migrationBuilder.DropIndex(
                name: "IX_PERSONAS_SISTEMAS_ID_PER",
                table: "PERSONAS_SISTEMAS");

            migrationBuilder.DropIndex(
                name: "IX_PERSONAS_SISTEMAS_ID_SISTEMA",
                table: "PERSONAS_SISTEMAS");

            migrationBuilder.AddColumn<int>(
                name: "SISTEMASID_SISTEMA",
                table: "PERSONAS_SISTEMAS",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PERSONAS_SISTEMAS",
                table: "PERSONAS_SISTEMAS",
                columns: new[] { "ID_PER", "ID_PERMISOS_SISTEMA" });

            migrationBuilder.CreateIndex(
                name: "IX_PERSONAS_SISTEMAS_ID_PERMISOS_SISTEMA",
                table: "PERSONAS_SISTEMAS",
                column: "ID_PERMISOS_SISTEMA");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONAS_SISTEMAS_SISTEMASID_SISTEMA",
                table: "PERSONAS_SISTEMAS",
                column: "SISTEMASID_SISTEMA");

            migrationBuilder.AddForeignKey(
                name: "FK_PERSONAS_SISTEMAS_SISTEMAS_SISTEMASID_SISTEMA",
                table: "PERSONAS_SISTEMAS",
                column: "SISTEMASID_SISTEMA",
                principalTable: "SISTEMAS",
                principalColumn: "ID_SISTEMA",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
