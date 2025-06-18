using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Transporte.API.Migrations
{
    /// <inheritdoc />
    public partial class v01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Camiones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Año = table.Column<int>(type: "int", nullable: false),
                    Placa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KmActual = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Camiones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Conductores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Licencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conductores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Talleres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapacidadMaxReparaciones = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talleres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CamionConductor",
                columns: table => new
                {
                    CamionesId = table.Column<int>(type: "int", nullable: false),
                    ConductorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CamionConductor", x => new { x.CamionesId, x.ConductorId });
                    table.ForeignKey(
                        name: "FK_CamionConductor_Camiones_CamionesId",
                        column: x => x.CamionesId,
                        principalTable: "Camiones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CamionConductor_Conductores_ConductorId",
                        column: x => x.ConductorId,
                        principalTable: "Conductores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mantenimientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TallerId = table.Column<int>(type: "int", nullable: false),
                    CamionId = table.Column<int>(type: "int", nullable: false),
                    ConductorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mantenimientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mantenimientos_Camiones_CamionId",
                        column: x => x.CamionId,
                        principalTable: "Camiones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mantenimientos_Conductores_ConductorId",
                        column: x => x.ConductorId,
                        principalTable: "Conductores",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Mantenimientos_Talleres_TallerId",
                        column: x => x.TallerId,
                        principalTable: "Talleres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CamionConductor_ConductorId",
                table: "CamionConductor",
                column: "ConductorId");

            migrationBuilder.CreateIndex(
                name: "IX_Mantenimientos_CamionId",
                table: "Mantenimientos",
                column: "CamionId");

            migrationBuilder.CreateIndex(
                name: "IX_Mantenimientos_ConductorId",
                table: "Mantenimientos",
                column: "ConductorId");

            migrationBuilder.CreateIndex(
                name: "IX_Mantenimientos_TallerId",
                table: "Mantenimientos",
                column: "TallerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CamionConductor");

            migrationBuilder.DropTable(
                name: "Mantenimientos");

            migrationBuilder.DropTable(
                name: "Camiones");

            migrationBuilder.DropTable(
                name: "Conductores");

            migrationBuilder.DropTable(
                name: "Talleres");
        }
    }
}
