using ProyectoIIITrimProgramacion_Mecarap.Models;
namespace ProyectoIIITrimProgramacion_Mecarap.Datos.Repositorio.IRepositorio
{
    public interface IClienteRepositorio : IRepositorio<Cliente>
    {
        void Actualizar(Cliente cliente);
    }
}