using Microsoft.EntityFrameworkCore.Migrations;

namespace MinInt.ModuloWeb.Personas.Persistence.Database.Migrations
{
    public partial class mod2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SISTEMAS_PERSONAS_PERSONAID_PER",
                table: "SISTEMAS");

            migrationBuilder.DropTable(
                name: "PERMISOS");

            migrationBuilder.DropIndex(
                name: "IX_SISTEMAS_PERSONAID_PER",
                table: "SISTEMAS");

            migrationBuilder.DropColumn(
                name: "PERSONAID_PER",
                table: "SISTEMAS");

            migrationBuilder.AddColumn<int>(
                name: "PersonasID_PER",
                table: "SISTEMAS",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ID_SISTEMA",
                table: "PERSONAS_SISTEMAS",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SISTEMASID_SISTEMA",
                table: "PERSONAS_SISTEMAS",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SISTEMAS_PersonasID_PER",
                table: "SISTEMAS",
                column: "PersonasID_PER");

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

            migrationBuilder.AddForeignKey(
                name: "FK_SISTEMAS_PERSONAS_PersonasID_PER",
                table: "SISTEMAS",
                column: "PersonasID_PER",
                principalTable: "PERSONAS",
                principalColumn: "ID_PER",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PERSONAS_SISTEMAS_SISTEMAS_SISTEMASID_SISTEMA",
                table: "PERSONAS_SISTEMAS");

            migrationBuilder.DropForeignKey(
                name: "FK_SISTEMAS_PERSONAS_PersonasID_PER",
                table: "SISTEMAS");

            migrationBuilder.DropIndex(
                name: "IX_SISTEMAS_PersonasID_PER",
                table: "SISTEMAS");

            migrationBuilder.DropIndex(
                name: "IX_PERSONAS_SISTEMAS_SISTEMASID_SISTEMA",
                table: "PERSONAS_SISTEMAS");

            migrationBuilder.DropColumn(
                name: "PersonasID_PER",
                table: "SISTEMAS");

            migrationBuilder.DropColumn(
                name: "ID_SISTEMA",
                table: "PERSONAS_SISTEMAS");

            migrationBuilder.DropColumn(
                name: "SISTEMASID_SISTEMA",
                table: "PERSONAS_SISTEMAS");

            migrationBuilder.AddColumn<int>(
                name: "PERSONAID_PER",
                table: "SISTEMAS",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PERMISOS",
                columns: table => new
                {
                    ID_PERMISO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRIPCION = table.Column<string>(type: "varchar(50)", nullable: true),
                    SISTEMAID_SISTEMA = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERMISOS", x => x.ID_PERMISO);
                    table.ForeignKey(
                        name: "FK_PERMISOS_SISTEMAS_SISTEMAID_SISTEMA",
                        column: x => x.SISTEMAID_SISTEMA,
                        principalTable: "SISTEMAS",
                        principalColumn: "ID_SISTEMA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SISTEMAS_PERSONAID_PER",
                table: "SISTEMAS",
                column: "PERSONAID_PER");

            migrationBuilder.CreateIndex(
                name: "IX_PERMISOS_SISTEMAID_SISTEMA",
                table: "PERMISOS",
                column: "SISTEMAID_SISTEMA");

            migrationBuilder.AddForeignKey(
                name: "FK_SISTEMAS_PERSONAS_PERSONAID_PER",
                table: "SISTEMAS",
                column: "PERSONAID_PER",
                principalTable: "PERSONAS",
                principalColumn: "ID_PER",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
