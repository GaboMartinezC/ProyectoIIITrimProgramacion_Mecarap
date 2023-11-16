using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoIIITrimProgramacion_Mecarap.Models;
namespace ProyectoIIITrimProgramacion_Mecarap.Datos.Repositorio.IRepositorio
{
    public interface IObservacionRepositorio : IRepositorio<Observacion>
    {
        void Actualizar(Observacion observacion);


    }
}