using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoIIITrimProgramacion_Mecarap.Datos;
using ProyectoIIITrimProgramacion_Mecarap.Datos.Repositorio.IRepositorio;
using ProyectoIIITrimProgramacion_Mecarap.Models;
using ProyectoIIITrimProgramacion_Mecarap.Models.ViewModels;

namespace ProyectoIIITrimProgramacion_Mecarap.Controllers
{
    public class ObservacionController : Controller
    {


        private readonly IObservacionRepositorio _repoObservacion;
        private readonly IClienteRepositorio _repoCliente;
        private readonly IVehiculoRepositorio _repoVehiculo;
        public IActionResult Index()
        {
            IEnumerable<Observacion> lista = _repoObservacion.ObtenerTodos(incluirPropiedades: "Observaciones");
            return View(lista);
        }

        public IActionResult Guardar()
        {
            ObservacionVM vm = new();
            vm.vehiculos = _repoVehiculo.ObtenerTodos();
            vm.clientes = _repoCliente.ObtenerTodos();
            return View(vm);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Guardar(ObservacionVM vm)
        {
            IEnumerable<Observacion> dbset = _repoObservacion.ObtenerTodos();
            foreach (var observacion in dbset)
            {
                if (observacion.Descripcion == vm.Descripcion.Trim())
                {

                    vm.vehiculos = _repoVehiculo.ObtenerTodos();
                    vm.clientes = _repoCliente.ObtenerTodos();
                    return View(vm);

                }
            }
            Observacion observaciones = new()
            {
                Descripcion = vm.Descripcion.Trim(),
                Fecha = vm.Fecha.Trim()

            };
            _repoObservacion.Agregar(observaciones);
            _repoObservacion.Grabar();
            return RedirectToAction("Index");
        }


        public IActionResult Editar(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            Observacion? observacion = _repoObservacion.Obtener(id);
            ObservacionVM vm = new()
            {
                Descripcion = observacion.Descripcion,
                Fecha = observacion.Fecha,
                vehiculos = _repoVehiculo.ObtenerTodos(),
                clientes = _repoCliente.ObtenerTodos()
            };
            return View(vm);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Editar(ObservacionVM vm)
        {
            Observacion observacion = new()
            {
                Id = vm.Id,
                Descripcion = vm.Descripcion,
                Fecha = vm.Fecha
            };
            _repoObservacion.Actualizar(observacion);
            _repoObservacion.Grabar();
            return RedirectToAction("Index");
        }


        public IActionResult Eliminar(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var observacion = _repoObservacion.Obtener(id);

            if (observacion == null)
            {
                return NotFound();
            }

            return View(observacion);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Eliminar(Observacion observacion)
        {
            Observacion observaciones = _repoObservacion.Obtener(observacion.Id);
            if (observacion == null)
            {
                return NotFound();
            }

            _repoObservacion.Remover(observaciones);
            _repoObservacion.Grabar();

            return RedirectToAction("Index");
        }
    }
}