using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MinInt.ModuloWeb.Personas.Persistence.Database.Migrations
{
    public partial class mod0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ESTADO_CAMBIOS",
                columns: table => new
                {
                    ID_ESTADO_CAMBIO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRIPCION = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESTADO_CAMBIOS", x => x.ID_ESTADO_CAMBIO);
                });

            migrationBuilder.CreateTable(
                name: "ESTADO_PERSONA",
                columns: table => new
                {
                    ID_ESTADO_PERSONA = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRIPCION = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESTADO_PERSONA", x => x.ID_ESTADO_PERSONA);
                });

            migrationBuilder.CreateTable(
                name: "JEFATURA",
                columns: table => new
                {
                    ID_JEFATURA = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TITULO = table.Column<string>(type: "varchar(40)", nullable: true),
                    ID_JEFE = table.Column<int>(nullable: false),
                    ID_SUBROGANTE = table.Column<int>(nullable: false),
                    ID_EVALUADOR = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JEFATURA", x => x.ID_JEFATURA);
                });

            migrationBuilder.CreateTable(
                name: "ORIENTACION",
                columns: table => new
                {
                    COD_ORIENTACION = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ORIENTACION = table.Column<string>(type: "varchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORIENTACION", x => x.COD_ORIENTACION);
                });

            migrationBuilder.CreateTable(
                name: "PERMISOS_SISTEMAS",
                columns: table => new
                {
                    ID_PERMISOS_SISTEMA = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRIPCION = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERMISOS_SISTEMAS", x => x.ID_PERMISOS_SISTEMA);
                });

            migrationBuilder.CreateTable(
                name: "PERMISOS_USUARIOS",
                columns: table => new
                {
                    ID_PERMISOS_USUARIOS = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRIPCION = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERMISOS_USUARIOS", x => x.ID_PERMISOS_USUARIOS);
                });

            migrationBuilder.CreateTable(
                name: "TIPO_SOLICITUD",
                columns: table => new
                {
                    COD_TIPO_SOLICITUD = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRIPCION = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIPO_SOLICITUD", x => x.COD_TIPO_SOLICITUD);
                });

            migrationBuilder.CreateTable(
                name: "PERSONAS",
                columns: table => new
                {
                    ID_PER = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMBRES = table.Column<string>(type: "varchar(40)", nullable: true),
                    AP_PATERNO = table.Column<string>(type: "varchar(20)", nullable: true),
                    AP_MATERNO = table.Column<string>(type: "varchar(20)", nullable: true),
                    ESTADO = table.Column<int>(nullable: false),
                    RUT = table.Column<int>(nullable: true),
                    DIG_VER = table.Column<string>(type: "varchar(1)", nullable: true),
                    CORREO_ELECTRONICO = table.Column<string>(type: "varchar(30)", nullable: true),
                    PASSWORD = table.Column<string>(type: "varchar(max)", nullable: true),
                    ID_JEFATURA = table.Column<int>(nullable: false),
                    ID_ESTADO_PERSONA = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERSONAS", x => x.ID_PER);
                    table.ForeignKey(
                        name: "FK_PERSONAS_ESTADO_PERSONA_ID_ESTADO_PERSONA",
                        column: x => x.ID_ESTADO_PERSONA,
                        principalTable: "ESTADO_PERSONA",
                        principalColumn: "ID_ESTADO_PERSONA",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PERSONAS_JEFATURA_ID_JEFATURA",
                        column: x => x.ID_JEFATURA,
                        principalTable: "JEFATURA",
                        principalColumn: "ID_JEFATURA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CAMBIOS",
                columns: table => new
                {
                    ID_CAMBIO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FECHA = table.Column<DateTime>(type: "date", nullable: false),
                    DESCRIPCION = table.Column<string>(type: "varchar(50)", nullable: true),
                    ID_PER = table.Column<int>(nullable: false),
                    ID_ESTADO_CAMBIO = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAMBIOS", x => x.ID_CAMBIO);
                    table.ForeignKey(
                        name: "FK_CAMBIOS_ESTADO_CAMBIOS_ID_ESTADO_CAMBIO",
                        column: x => x.ID_ESTADO_CAMBIO,
                        principalTable: "ESTADO_CAMBIOS",
                        principalColumn: "ID_ESTADO_CAMBIO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CAMBIOS_PERSONAS_ID_PER",
                        column: x => x.ID_PER,
                        principalTable: "PERSONAS",
                        principalColumn: "ID_PER",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PERSONAS_SISTEMAS",
                columns: table => new
                {
                    ID_PER = table.Column<int>(nullable: false),
                    ID_PERMISOS_SISTEMA = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERSONAS_SISTEMAS", x => new { x.ID_PER, x.ID_PERMISOS_SISTEMA });
                    table.ForeignKey(
                        name: "FK_PERSONAS_SISTEMAS_PERSONAS_ID_PER",
                        column: x => x.ID_PER,
                        principalTable: "PERSONAS",
                        principalColumn: "ID_PER",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PERSONAS_SISTEMAS_PERMISOS_SISTEMAS_ID_PERMISOS_SISTEMA",
                        column: x => x.ID_PERMISOS_SISTEMA,
                        principalTable: "PERMISOS_SISTEMAS",
                        principalColumn: "ID_PERMISOS_SISTEMA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PERSONAS_USUARIOS",
                columns: table => new
                {
                    ID_PER = table.Column<int>(nullable: false),
                    ID_PERMISOS_USUARIOS = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERSONAS_USUARIOS", x => new { x.ID_PER, x.ID_PERMISOS_USUARIOS });
                    table.ForeignKey(
                        name: "FK_PERSONAS_USUARIOS_PERSONAS_ID_PER",
                        column: x => x.ID_PER,
                        principalTable: "PERSONAS",
                        principalColumn: "ID_PER",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PERSONAS_USUARIOS_PERMISOS_USUARIOS_ID_PERMISOS_USUARIOS",
                        column: x => x.ID_PERMISOS_USUARIOS,
                        principalTable: "PERMISOS_USUARIOS",
                        principalColumn: "ID_PERMISOS_USUARIOS",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "REGISTRO_ENTRADA_SALIDA",
                columns: table => new
                {
                    COD_ENTSAL = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FECHA = table.Column<DateTime>(type: "datetime", nullable: false),
                    HORA = table.Column<DateTime>(type: "datetime", nullable: false),
                    ID_PER = table.Column<int>(nullable: false),
                    COD_ORIENTACION = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REGISTRO_ENTRADA_SALIDA", x => x.COD_ENTSAL);
                    table.ForeignKey(
                        name: "FK_REGISTRO_ENTRADA_SALIDA_ORIENTACION_COD_ORIENTACION",
                        column: x => x.COD_ORIENTACION,
                        principalTable: "ORIENTACION",
                        principalColumn: "COD_ORIENTACION",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_REGISTRO_ENTRADA_SALIDA_PERSONAS_ID_PER",
                        column: x => x.ID_PER,
                        principalTable: "PERSONAS",
                        principalColumn: "ID_PER",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SISTEMAS",
                columns: table => new
                {
                    ID_SISTEMA = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRIPCION = table.Column<string>(type: "varchar(50)", nullable: true),
                    PERSONAID_PER = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SISTEMAS", x => x.ID_SISTEMA);
                    table.ForeignKey(
                        name: "FK_SISTEMAS_PERSONAS_PERSONAID_PER",
                        column: x => x.PERSONAID_PER,
                        principalTable: "PERSONAS",
                        principalColumn: "ID_PER",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SOLICITUD",
                columns: table => new
                {
                    COD_SOLICITUD = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FECHA_PETICION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHA_RESPUESTA = table.Column<DateTime>(type: "datetime", nullable: true),
                    AUTORIZADO_POR = table.Column<int>(nullable: true),
                    ID_PER = table.Column<int>(nullable: false),
                    COD_TIPO_SOLICITUD = table.Column<int>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "PERMISOS",
                columns: table => new
                {
                    ID_PERMISO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRIPCION = table.Column<string>(type: "varchar(50)", nullable: true),
                    SISTEMAID_SISTEMA = table.Column<int>(nullable: true)
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

            migrationBuilder.InsertData(
                table: "ESTADO_PERSONA",
                columns: new[] { "ID_ESTADO_PERSONA", "DESCRIPCION" },
                values: new object[] { 1, "Tipo de estado 1" });

            migrationBuilder.InsertData(
                table: "JEFATURA",
                columns: new[] { "ID_JEFATURA", "ID_EVALUADOR", "ID_JEFE", "ID_SUBROGANTE", "TITULO" },
                values: new object[] { 1, 1, 1, 1, "Tipo de Jefatura 1" });

            migrationBuilder.InsertData(
                table: "PERMISOS_SISTEMAS",
                columns: new[] { "ID_PERMISOS_SISTEMA", "DESCRIPCION" },
                values: new object[,]
                {
                    { 1, "Tipo de acceso 1" },
                    { 2, "Tipo de acceso 2" }
                });

            migrationBuilder.InsertData(
                table: "PERMISOS_USUARIOS",
                columns: new[] { "ID_PERMISOS_USUARIOS", "DESCRIPCION" },
                values: new object[,]
                {
                    { 1, "Tipo de acceso 1" },
                    { 2, "Tipo de acceso 2" }
                });

            migrationBuilder.InsertData(
                table: "TIPO_SOLICITUD",
                columns: new[] { "COD_TIPO_SOLICITUD", "DESCRIPCION" },
                values: new object[,]
                {
                    { 1, "Tipo de solicitud 1" },
                    { 2, "Tipo de solicitud 2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CAMBIOS_ID_CAMBIO",
                table: "CAMBIOS",
                column: "ID_CAMBIO");

            migrationBuilder.CreateIndex(
                name: "IX_CAMBIOS_ID_ESTADO_CAMBIO",
                table: "CAMBIOS",
                column: "ID_ESTADO_CAMBIO");

            migrationBuilder.CreateIndex(
                name: "IX_CAMBIOS_ID_PER",
                table: "CAMBIOS",
                column: "ID_PER");

            migrationBuilder.CreateIndex(
                name: "IX_ESTADO_CAMBIOS_ID_ESTADO_CAMBIO",
                table: "ESTADO_CAMBIOS",
                column: "ID_ESTADO_CAMBIO");

            migrationBuilder.CreateIndex(
                name: "IX_ESTADO_PERSONA_ID_ESTADO_PERSONA",
                table: "ESTADO_PERSONA",
                column: "ID_ESTADO_PERSONA");

            migrationBuilder.CreateIndex(
                name: "IX_JEFATURA_ID_JEFATURA",
                table: "JEFATURA",
                column: "ID_JEFATURA");

            migrationBuilder.CreateIndex(
                name: "IX_ORIENTACION_COD_ORIENTACION",
                table: "ORIENTACION",
                column: "COD_ORIENTACION");

            migrationBuilder.CreateIndex(
                name: "IX_PERMISOS_SISTEMAID_SISTEMA",
                table: "PERMISOS",
                column: "SISTEMAID_SISTEMA");

            migrationBuilder.CreateIndex(
                name: "IX_PERMISOS_SISTEMAS_ID_PERMISOS_SISTEMA",
                table: "PERMISOS_SISTEMAS",
                column: "ID_PERMISOS_SISTEMA");

            migrationBuilder.CreateIndex(
                name: "IX_PERMISOS_USUARIOS_ID_PERMISOS_USUARIOS",
                table: "PERMISOS_USUARIOS",
                column: "ID_PERMISOS_USUARIOS");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONAS_ID_ESTADO_PERSONA",
                table: "PERSONAS",
                column: "ID_ESTADO_PERSONA");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONAS_ID_JEFATURA",
                table: "PERSONAS",
                column: "ID_JEFATURA");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONAS_ID_PER",
                table: "PERSONAS",
                column: "ID_PER");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONAS_SISTEMAS_ID_PERMISOS_SISTEMA",
                table: "PERSONAS_SISTEMAS",
                column: "ID_PERMISOS_SISTEMA");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONAS_USUARIOS_ID_PERMISOS_USUARIOS",
                table: "PERSONAS_USUARIOS",
                column: "ID_PERMISOS_USUARIOS");

            migrationBuilder.CreateIndex(
                name: "IX_REGISTRO_ENTRADA_SALIDA_COD_ENTSAL",
                table: "REGISTRO_ENTRADA_SALIDA",
                column: "COD_ENTSAL");

            migrationBuilder.CreateIndex(
                name: "IX_REGISTRO_ENTRADA_SALIDA_COD_ORIENTACION",
                table: "REGISTRO_ENTRADA_SALIDA",
                column: "COD_ORIENTACION");

            migrationBuilder.CreateIndex(
                name: "IX_REGISTRO_ENTRADA_SALIDA_ID_PER",
                table: "REGISTRO_ENTRADA_SALIDA",
                column: "ID_PER");

            migrationBuilder.CreateIndex(
                name: "IX_SISTEMAS_PERSONAID_PER",
                table: "SISTEMAS",
                column: "PERSONAID_PER");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CAMBIOS");

            migrationBuilder.DropTable(
                name: "PERMISOS");

            migrationBuilder.DropTable(
                name: "PERSONAS_SISTEMAS");

            migrationBuilder.DropTable(
                name: "PERSONAS_USUARIOS");

            migrationBuilder.DropTable(
                name: "REGISTRO_ENTRADA_SALIDA");

            migrationBuilder.DropTable(
                name: "SOLICITUD");

            migrationBuilder.DropTable(
                name: "ESTADO_CAMBIOS");

            migrationBuilder.DropTable(
                name: "SISTEMAS");

            migrationBuilder.DropTable(
                name: "PERMISOS_SISTEMAS");

            migrationBuilder.DropTable(
                name: "PERMISOS_USUARIOS");

            migrationBuilder.DropTable(
                name: "ORIENTACION");

            migrationBuilder.DropTable(
                name: "TIPO_SOLICITUD");

            migrationBuilder.DropTable(
                name: "PERSONAS");

            migrationBuilder.DropTable(
                name: "ESTADO_PERSONA");

            migrationBuilder.DropTable(
                name: "JEFATURA");
        }
    }
}
