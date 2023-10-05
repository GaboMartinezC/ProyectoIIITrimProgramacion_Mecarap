using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoIIITrimProgramacion_Mecarap.Migrations
{
    /// <inheritdoc />
    public partial class migracionFinal3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reparaciones_Usuarios_IdMecanico",
                table: "Reparaciones");

            migrationBuilder.DropIndex(
                name: "IX_Reparaciones_IdMecanico",
                table: "Reparaciones");

            migrationBuilder.DropColumn(
                name: "IdMecanico",
                table: "Reparaciones");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdMecanico",
                table: "Reparaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reparaciones_IdMecanico",
                table: "Reparaciones",
                column: "IdMecanico");

            migrationBuilder.AddForeignKey(
                name: "FK_Reparaciones_Usuarios_IdMecanico",
                table: "Reparaciones",
                column: "IdMecanico",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
