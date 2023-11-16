using ProyectoIIITrimProgramacion_Mecarap.Models;
namespace ProyectoIIITrimProgramacion_Mecarap.Models.ViewModels
{
    public class UsuarioVM : Reparacion
    {
        public string nombre { get; set; }
        public string pass { get; set; }
        public string? tipoUsuario {  get; set; }
    }
}