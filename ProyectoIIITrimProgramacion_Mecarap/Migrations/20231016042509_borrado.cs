using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoIIITrimProgramacion_Mecarap.Migrations
{
    /// <inheritdoc />
    public partial class borrado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Borrado",
                table: "Vehiculos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Borrado",
                table: "Usuarios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Borrado",
                table: "TiposUsuario",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Borrado",
                table: "TiposAuto",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Borrado",
                table: "Progresos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Borrado",
                table: "Observaciones",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Borrado",
                table: "Mecanicos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Borrado",
                table: "HojasIngreso",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Borrado",
                table: "Vehiculos");

            migrationBuilder.DropColumn(
                name: "Borrado",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Borrado",
                table: "TiposUsuario");

            migrationBuilder.DropColumn(
                name: "Borrado",
                table: "TiposAuto");

            migrationBuilder.DropColumn(
                name: "Borrado",
                table: "Progresos");

            migrationBuilder.DropColumn(
                name: "Borrado",
                table: "Observaciones");

            migrationBuilder.DropColumn(
                name: "Borrado",
                table: "Mecanicos");

            migrationBuilder.DropColumn(
                name: "Borrado",
                table: "HojasIngreso");
        }
    }
}
