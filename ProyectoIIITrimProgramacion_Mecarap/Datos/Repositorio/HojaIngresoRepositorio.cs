using ProyectoIIITrimProgramacion_Mecarap.Datos.Repositorio.IRepositorio;
using ProyectoIIITrimProgramacion_Mecarap.Models;
namespace ProyectoIIITrimProgramacion_Mecarap.Datos.Repositorio
{
    public class HojaIngresoRepositorio : Repositorio<HojaIngreso>, IHojaIngresoRepositorio
    {
        private readonly ApplicationDbContext _db;
        public HojaIngresoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
