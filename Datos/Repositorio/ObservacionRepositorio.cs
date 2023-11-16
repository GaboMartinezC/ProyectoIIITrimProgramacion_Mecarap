using ProyectoIIITrimProgramacion_Mecarap.Models;
using ProyectoIIITrimProgramacion_Mecarap.Datos.Repositorio.IRepositorio;

namespace ProyectoIIITrimProgramacion_Mecarap.Datos.Repositorio
{
    public class ObservacionRepositorio : Repositorio<Observacion>, IObservacionRepositorio
    {
        private readonly ApplicationDbContext _db;

        public ObservacionRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Observacion observacion)
        {
            _db.Update(observacion);
        }



    }
}
