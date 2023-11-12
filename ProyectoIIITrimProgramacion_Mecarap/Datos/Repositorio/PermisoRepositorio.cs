using ProyectoIIITrimProgramacion_Mecarap.Datos.Repositorio.IRepositorio;
using ProyectoIIITrimProgramacion_Mecarap.Models;
namespace ProyectoIIITrimProgramacion_Mecarap.Datos.Repositorio
{
    public class PermisoRepositorio : Repositorio<Permiso>, IPermisoRepositorio
    {
        private readonly ApplicationDbContext _db;
        public PermisoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
