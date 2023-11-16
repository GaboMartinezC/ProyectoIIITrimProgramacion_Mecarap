using ProyectoIIITrimProgramacion_Mecarap.Models;
namespace ProyectoIIITrimProgramacion_Mecarap.Models.ViewModels
{
    public class ReparacionVM : Reparacion
    {
        public IEnumerable<Reparacion>? Reparaciones { get; set; }
        public IEnumerable<Mecanico>? Mecanicos { get; set; }
        public IEnumerable<Vehiculo>? Vehiculos { get; set; }
        public IEnumerable<Estado>? Estados { get; set; }
    }
}
