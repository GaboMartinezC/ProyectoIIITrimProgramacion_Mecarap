using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoIIITrimProgramacion_Mecarap.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Borrado",
                table: "Permisos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "InformesFinal",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Borrado",
                table: "Permisos");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "InformesFinal");
        }
    }
}
