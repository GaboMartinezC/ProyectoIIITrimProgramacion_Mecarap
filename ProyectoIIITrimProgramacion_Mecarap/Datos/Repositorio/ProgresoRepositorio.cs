using ProyectoIIITrimProgramacion_Mecarap.Datos.Repositorio.IRepositorio;
using ProyectoIIITrimProgramacion_Mecarap.Models;
namespace ProyectoIIITrimProgramacion_Mecarap.Datos.Repositorio
{
    public class ProgresoRepositorio : Repositorio<Progreso>, IProgresoRepositorio
    {
        private readonly ApplicationDbContext _db;
        public ProgresoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
