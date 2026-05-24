using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartBike.API.Migrations
{
    /// <inheritdoc />
    public partial class BASE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoTransportes",
                columns: table => new
                {
                    idtiptra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    detalles = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    es_cero_emision = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTransportes", x => x.idtiptra);
                });

            migrationBuilder.CreateTable(
                name: "TipoUsuarios",
                columns: table => new
                {
                    idtip = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    detalle = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsuarios", x => x.idtip);
                });

            migrationBuilder.CreateTable(
                name: "ConteoCamaras",
                columns: table => new
                {
                    id_conte_cama = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_camara = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ip_camara = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false),
                    id_tipo_transporte = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConteoCamaras", x => x.id_conte_cama);
                    table.ForeignKey(
                        name: "FK_ConteoCamaras_TipoTransportes_id_tipo_transporte",
                        column: x => x.id_tipo_transporte,
                        principalTable: "TipoTransportes",
                        principalColumn: "idtiptra",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reportes",
                columns: table => new
                {
                    idrep = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha_generacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    periodo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    total_co2 = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    id_tipo_transporte = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reportes", x => x.idrep);
                    table.ForeignKey(
                        name: "FK_Reportes_TipoTransportes_id_tipo_transporte",
                        column: x => x.id_tipo_transporte,
                        principalTable: "TipoTransportes",
                        principalColumn: "idtiptra",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    cedula = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    nombres = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    apellidos = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    correo_institucional = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    fecharegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    id_tipo_usuario = table.Column<int>(type: "int", nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.cedula);
                    table.ForeignKey(
                        name: "FK_Usuarios_TipoUsuarios_id_tipo_usuario",
                        column: x => x.id_tipo_usuario,
                        principalTable: "TipoUsuarios",
                        principalColumn: "idtip",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Camaras",
                columns: table => new
                {
                    idcam = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_camara = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_tipo_transporte = table.Column<int>(type: "int", nullable: false),
                    id_usuario = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    fecha_hora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ip_camara = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Camaras", x => x.idcam);
                    table.ForeignKey(
                        name: "FK_Camaras_TipoTransportes_id_tipo_transporte",
                        column: x => x.id_tipo_transporte,
                        principalTable: "TipoTransportes",
                        principalColumn: "idtiptra",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Camaras_Usuarios_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "Usuarios",
                        principalColumn: "cedula");
                });

            migrationBuilder.CreateTable(
                name: "Historiales",
                columns: table => new
                {
                    idhi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    co2_acumulado = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    id_usuario = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    id_tipo_transporte = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historiales", x => x.idhi);
                    table.ForeignKey(
                        name: "FK_Historiales_TipoTransportes_id_tipo_transporte",
                        column: x => x.id_tipo_transporte,
                        principalTable: "TipoTransportes",
                        principalColumn: "idtiptra",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Historiales_Usuarios_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "Usuarios",
                        principalColumn: "cedula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegistroDiarios",
                columns: table => new
                {
                    idreg = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    co2_generado = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    id_usuario = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    id_tipo_transporte = table.Column<int>(type: "int", nullable: false),
                    id_camara = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroDiarios", x => x.idreg);
                    table.ForeignKey(
                        name: "FK_RegistroDiarios_Camaras_id_camara",
                        column: x => x.id_camara,
                        principalTable: "Camaras",
                        principalColumn: "idcam");
                    table.ForeignKey(
                        name: "FK_RegistroDiarios_TipoTransportes_id_tipo_transporte",
                        column: x => x.id_tipo_transporte,
                        principalTable: "TipoTransportes",
                        principalColumn: "idtiptra");
                    table.ForeignKey(
                        name: "FK_RegistroDiarios_Usuarios_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "Usuarios",
                        principalColumn: "cedula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Camaras_id_tipo_transporte",
                table: "Camaras",
                column: "id_tipo_transporte");

            migrationBuilder.CreateIndex(
                name: "IX_Camaras_id_usuario",
                table: "Camaras",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_ConteoCamaras_id_tipo_transporte",
                table: "ConteoCamaras",
                column: "id_tipo_transporte");

            migrationBuilder.CreateIndex(
                name: "IX_Historiales_id_tipo_transporte",
                table: "Historiales",
                column: "id_tipo_transporte");

            migrationBuilder.CreateIndex(
                name: "IX_Historiales_id_usuario",
                table: "Historiales",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroDiarios_id_camara",
                table: "RegistroDiarios",
                column: "id_camara");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroDiarios_id_tipo_transporte",
                table: "RegistroDiarios",
                column: "id_tipo_transporte");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroDiarios_id_usuario",
                table: "RegistroDiarios",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Reportes_id_tipo_transporte",
                table: "Reportes",
                column: "id_tipo_transporte");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_id_tipo_usuario",
                table: "Usuarios",
                column: "id_tipo_usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConteoCamaras");

            migrationBuilder.DropTable(
                name: "Historiales");

            migrationBuilder.DropTable(
                name: "RegistroDiarios");

            migrationBuilder.DropTable(
                name: "Reportes");

            migrationBuilder.DropTable(
                name: "Camaras");

            migrationBuilder.DropTable(
                name: "TipoTransportes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "TipoUsuarios");
        }
    }
}
