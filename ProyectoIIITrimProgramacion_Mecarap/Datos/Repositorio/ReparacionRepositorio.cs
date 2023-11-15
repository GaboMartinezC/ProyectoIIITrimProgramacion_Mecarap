using ProyectoIIITrimProgramacion_Mecarap.Datos.Repositorio.IRepositorio;
using ProyectoIIITrimProgramacion_Mecarap.Models;
namespace ProyectoIIITrimProgramacion_Mecarap.Datos.Repositorio
{
    public class ReparacionRepositorio : Repositorio<Reparacion>, IReparacionRepositorio
    {
        private readonly ApplicationDbContext _db;
        public ReparacionRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
