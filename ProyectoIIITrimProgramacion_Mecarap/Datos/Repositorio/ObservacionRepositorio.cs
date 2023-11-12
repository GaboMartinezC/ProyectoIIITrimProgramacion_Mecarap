using ProyectoIIITrimProgramacion_Mecarap.Datos.Repositorio.IRepositorio;
using ProyectoIIITrimProgramacion_Mecarap.Models;
namespace ProyectoIIITrimProgramacion_Mecarap.Datos.Repositorio
{
    public class ObservacionRepositorio : Repositorio<Observacion>, IObservacionRepositorio
    {
        private readonly ApplicationDbContext _db;
        public ObservacionRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
