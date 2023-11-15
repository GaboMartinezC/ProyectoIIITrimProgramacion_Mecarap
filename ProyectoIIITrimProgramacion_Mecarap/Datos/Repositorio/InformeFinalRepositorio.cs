using ProyectoIIITrimProgramacion_Mecarap.Datos.Repositorio.IRepositorio;
using ProyectoIIITrimProgramacion_Mecarap.Models;
namespace ProyectoIIITrimProgramacion_Mecarap.Datos.Repositorio
{
    public class InformeFinalRepositorio : Repositorio<InformeFinal>, IInformeFinalRepositorio
    {
        private readonly ApplicationDbContext _db;
        public InformeFinalRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
