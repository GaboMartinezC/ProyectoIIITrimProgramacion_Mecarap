using ProyectoIIITrimProgramacion_Mecarap.Datos.Repositorio.IRepositorio;
using ProyectoIIITrimProgramacion_Mecarap.Models;
namespace ProyectoIIITrimProgramacion_Mecarap.Datos.Repositorio
{
    public class MecanicoRepositorio : Repositorio<Mecanico>, IMecanicoRepositorio
    {
        private readonly ApplicationDbContext _db;
        public MecanicoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
