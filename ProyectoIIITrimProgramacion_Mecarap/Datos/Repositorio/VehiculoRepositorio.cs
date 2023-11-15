using ProyectoIIITrimProgramacion_Mecarap.Models;
using ProyectoIIITrimProgramacion_Mecarap.Datos.Repositorio.IRepositorio;

namespace ProyectoIIITrimProgramacion_Mecarap.Datos.Repositorio
{
    public class VehiculoRepositorio : Repositorio<Vehiculo>, IVehiculoRepositorio
    {
        private readonly ApplicationDbContext _db;
        public VehiculoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
