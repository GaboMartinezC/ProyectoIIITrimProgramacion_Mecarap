using ProyectoIIITrimProgramacion_Mecarap.Models;

namespace ProyectoIIITrimProgramacion_Mecarap.Models.ViewModels
{
    public class VehiculoVM : Vehiculo
    {
        public IEnumerable<TipoAuto>? tiposAuto { get; set; }
        public IEnumerable<Cliente>? clientes { get; set; }
        public string? tipoAuto { get; set; }
        public string? cliente { get; set; }
        public string Notificacion = "<div class=\"alert alert-warning alert-dismissible fade show m-3 p-3\" role=\"alert\">\r\n<strong>Registro ya existente</strong> Los datos de descripcion no se pueden repetir\r\n</div>";
    }
}
