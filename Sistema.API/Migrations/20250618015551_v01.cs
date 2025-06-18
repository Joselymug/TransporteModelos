using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Sistema.API.Migrations
{
    /// <inheritdoc />
    public partial class v01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Camion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Marca = table.Column<string>(type: "text", nullable: false),
                    Modelo = table.Column<string>(type: "text", nullable: false),
                    Año = table.Column<int>(type: "integer", nullable: false),
                    Placa = table.Column<string>(type: "text", nullable: false),
                    KmActual = table.Column<int>(type: "integer", nullable: false),
                    Estado = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Camion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Taller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Ciudad = table.Column<string>(type: "text", nullable: false),
                    CapacidadMaxReparaciones = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taller", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sensores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CamionId = table.Column<int>(type: "integer", nullable: false),
                    TipoSensor = table.Column<string>(type: "text", nullable: false),
                    Valor = table.Column<double>(type: "double precision", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sensores_Camion_CamionId",
                        column: x => x.CamionId,
                        principalTable: "Camion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mantenimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Tipo = table.Column<string>(type: "text", nullable: false),
                    TallerId = table.Column<int>(type: "integer", nullable: false),
                    CamionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mantenimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mantenimiento_Camion_CamionId",
                        column: x => x.CamionId,
                        principalTable: "Camion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mantenimiento_Taller_TallerId",
                        column: x => x.TallerId,
                        principalTable: "Taller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alertas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoAlerta = table.Column<string>(type: "text", nullable: false),
                    Valor = table.Column<double>(type: "double precision", nullable: false),
                    FechaGeneracion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SensorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alertas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alertas_Sensores_SensorId",
                        column: x => x.SensorId,
                        principalTable: "Sensores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Valor = table.Column<double>(type: "double precision", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SensorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logs_Sensores_SensorId",
                        column: x => x.SensorId,
                        principalTable: "Sensores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alertas_SensorId",
                table: "Alertas",
                column: "SensorId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_SensorId",
                table: "Logs",
                column: "SensorId");

            migrationBuilder.CreateIndex(
                name: "IX_Mantenimiento_CamionId",
                table: "Mantenimiento",
                column: "CamionId");

            migrationBuilder.CreateIndex(
                name: "IX_Mantenimiento_TallerId",
                table: "Mantenimiento",
                column: "TallerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sensores_CamionId",
                table: "Sensores",
                column: "CamionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alertas");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Mantenimiento");

            migrationBuilder.DropTable(
                name: "Sensores");

            migrationBuilder.DropTable(
                name: "Taller");

            migrationBuilder.DropTable(
                name: "Camion");
        }
    }
}
