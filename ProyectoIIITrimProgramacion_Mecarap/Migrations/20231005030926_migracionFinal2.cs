using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoIIITrimProgramacion_Mecarap.Migrations
{
    /// <inheritdoc />
    public partial class migracionFinal2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reparaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaSolicitada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdAuto = table.Column<int>(type: "int", nullable: false),
                    IdHojaIngreso = table.Column<int>(type: "int", nullable: false),
                    IdProgreso = table.Column<int>(type: "int", nullable: false),
                    IdInforme = table.Column<int>(type: "int", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    IdMecanico = table.Column<int>(type: "int", nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reparaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reparaciones_Estados_IdEstado",
                        column: x => x.IdEstado,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reparaciones_HojasIngreso_IdHojaIngreso",
                        column: x => x.IdHojaIngreso,
                        principalTable: "HojasIngreso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reparaciones_InformesFinal_IdInforme",
                        column: x => x.IdInforme,
                        principalTable: "InformesFinal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reparaciones_Progresos_IdProgreso",
                        column: x => x.IdProgreso,
                        principalTable: "Progresos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reparaciones_Usuarios_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reparaciones_Usuarios_IdMecanico",
                        column: x => x.IdMecanico,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reparaciones_Vehiculos_IdAuto",
                        column: x => x.IdAuto,
                        principalTable: "Vehiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reparaciones_IdAuto",
                table: "Reparaciones",
                column: "IdAuto");

            migrationBuilder.CreateIndex(
                name: "IX_Reparaciones_IdCliente",
                table: "Reparaciones",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Reparaciones_IdEstado",
                table: "Reparaciones",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Reparaciones_IdHojaIngreso",
                table: "Reparaciones",
                column: "IdHojaIngreso");

            migrationBuilder.CreateIndex(
                name: "IX_Reparaciones_IdInforme",
                table: "Reparaciones",
                column: "IdInforme");

            migrationBuilder.CreateIndex(
                name: "IX_Reparaciones_IdMecanico",
                table: "Reparaciones",
                column: "IdMecanico");

            migrationBuilder.CreateIndex(
                name: "IX_Reparaciones_IdProgreso",
                table: "Reparaciones",
                column: "IdProgreso");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reparaciones");
        }
    }
}
