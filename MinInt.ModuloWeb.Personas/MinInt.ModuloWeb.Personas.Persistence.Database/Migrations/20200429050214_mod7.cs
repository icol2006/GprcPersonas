using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MinInt.ModuloWeb.Personas.Persistence.Database.Migrations
{
    public partial class mod7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SOLICITUD");

            migrationBuilder.DropTable(
                name: "TIPO_SOLICITUD");

            migrationBuilder.DropColumn(
                name: "CENTRO_COSTO",
                table: "PERSONAS");

            migrationBuilder.AddColumn<int>(
                name: "ID_CENTRO_COSTO",
                table: "PERSONAS",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CENTRO_COSTO",
                columns: table => new
                {
                    ID_CENTRO_COSTO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRIPCION = table.Column<string>(type: "varchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CENTRO_COSTO", x => x.ID_CENTRO_COSTO);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PERSONAS_ID_CENTRO_COSTO",
                table: "PERSONAS",
                column: "ID_CENTRO_COSTO");

            migrationBuilder.AddForeignKey(
                name: "FK_PERSONAS_CENTRO_COSTO_ID_CENTRO_COSTO",
                table: "PERSONAS",
                column: "ID_CENTRO_COSTO",
                principalTable: "CENTRO_COSTO",
                principalColumn: "ID_CENTRO_COSTO",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PERSONAS_CENTRO_COSTO_ID_CENTRO_COSTO",
                table: "PERSONAS");

            migrationBuilder.DropTable(
                name: "CENTRO_COSTO");

            migrationBuilder.DropIndex(
                name: "IX_PERSONAS_ID_CENTRO_COSTO",
                table: "PERSONAS");

            migrationBuilder.DropColumn(
                name: "ID_CENTRO_COSTO",
                table: "PERSONAS");

            migrationBuilder.AddColumn<string>(
                name: "CENTRO_COSTO",
                table: "PERSONAS",
                type: "varchar(20)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TIPO_SOLICITUD",
                columns: table => new
                {
                    COD_TIPO_SOLICITUD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRIPCION = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIPO_SOLICITUD", x => x.COD_TIPO_SOLICITUD);
                });

            migrationBuilder.CreateTable(
                name: "SOLICITUD",
                columns: table => new
                {
                    COD_SOLICITUD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AUTORIZADO_POR = table.Column<int>(type: "int", nullable: true),
                    COD_TIPO_SOLICITUD = table.Column<int>(type: "int", nullable: false),
                    FECHA_PETICION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHA_RESPUESTA = table.Column<DateTime>(type: "datetime", nullable: true),
                    ID_PER = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SOLICITUD", x => x.COD_SOLICITUD);
                    table.ForeignKey(
                        name: "FK_SOLICITUD_TIPO_SOLICITUD_COD_TIPO_SOLICITUD",
                        column: x => x.COD_TIPO_SOLICITUD,
                        principalTable: "TIPO_SOLICITUD",
                        principalColumn: "COD_TIPO_SOLICITUD",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SOLICITUD_PERSONAS_ID_PER",
                        column: x => x.ID_PER,
                        principalTable: "PERSONAS",
                        principalColumn: "ID_PER",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TIPO_SOLICITUD",
                columns: new[] { "COD_TIPO_SOLICITUD", "DESCRIPCION" },
                values: new object[] { 1, "Tipo de solicitud 1" });

            migrationBuilder.InsertData(
                table: "TIPO_SOLICITUD",
                columns: new[] { "COD_TIPO_SOLICITUD", "DESCRIPCION" },
                values: new object[] { 2, "Tipo de solicitud 2" });

            migrationBuilder.CreateIndex(
                name: "IX_SOLICITUD_COD_SOLICITUD",
                table: "SOLICITUD",
                column: "COD_SOLICITUD");

            migrationBuilder.CreateIndex(
                name: "IX_SOLICITUD_COD_TIPO_SOLICITUD",
                table: "SOLICITUD",
                column: "COD_TIPO_SOLICITUD");

            migrationBuilder.CreateIndex(
                name: "IX_SOLICITUD_ID_PER",
                table: "SOLICITUD",
                column: "ID_PER");

            migrationBuilder.CreateIndex(
                name: "IX_TIPO_SOLICITUD_COD_TIPO_SOLICITUD",
                table: "TIPO_SOLICITUD",
                column: "COD_TIPO_SOLICITUD");
        }
    }
}
