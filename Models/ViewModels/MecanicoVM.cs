namespace ProyectoIIITrimProgramacion_Mecarap.Models.ViewModels
{
    public class MecanicoVM : Mecanico
    {
        public IEnumerable<TipoUsuario>? tiposUsuario { get; set; }
    }
}
