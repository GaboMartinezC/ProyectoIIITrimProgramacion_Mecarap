using ProyectoIIITrimProgramacion_Mecarap.Models;

namespace ProyectoIIITrimProgramacion_Mecarap.Models.ViewModels
{
    public class VehiculoVM : Vehiculo
    {
        public IEnumerable<TipoAuto>? tiposAuto { get; set; }
        public IEnumerable<Cliente>? clientes { get; set; }
        public string? tipoAuto { get; set; }
        public string? cliente { get; set; }
    }
}
