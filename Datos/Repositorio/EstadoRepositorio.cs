using ProyectoIIITrimProgramacion_Mecarap.Datos.Repositorio.IRepositorio;
using ProyectoIIITrimProgramacion_Mecarap.Models;
namespace ProyectoIIITrimProgramacion_Mecarap.Datos.Repositorio
{
    public class EstadoRepositorio : Repositorio<Estado>, IEstadoRepositorio
    {
        private readonly ApplicationDbContext _db;
        public EstadoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
