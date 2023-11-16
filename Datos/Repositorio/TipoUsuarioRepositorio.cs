using ProyectoIIITrimProgramacion_Mecarap.Datos.Repositorio.IRepositorio;
using ProyectoIIITrimProgramacion_Mecarap.Models;
namespace ProyectoIIITrimProgramacion_Mecarap.Datos.Repositorio
{
    public class TipoUsuarioRepositorio : Repositorio<TipoUsuario>, ITipoUsuarioRepositorio
    {
        private readonly ApplicationDbContext _db;
        public TipoUsuarioRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
