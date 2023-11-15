using ProyectoIIITrimProgramacion_Mecarap.Datos.Repositorio.IRepositorio;
using ProyectoIIITrimProgramacion_Mecarap.Models;
namespace ProyectoIIITrimProgramacion_Mecarap.Datos.Repositorio
{
    public class TipoAutoRepositorio : Repositorio<TipoAuto>, ITipoAutoRepositorio
    {
        private readonly ApplicationDbContext _db;
        public TipoAutoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
