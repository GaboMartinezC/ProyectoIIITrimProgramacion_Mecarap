using Microsoft.AspNetCore.Mvc;
using ProyectoIIITrimProgramacion_Mecarap.Models;
using ProyectoIIITrimProgramacion_Mecarap.Datos.Repositorio.IRepositorio;
using ProyectoIIITrimProgramacion_Mecarap.Models.ViewModels;

namespace ProyectoIIITrimProgramacion_Mecarap.Controllers
{
    public class ReparacionController : Controller
    {
        private readonly IReparacionRepositorio _repoReparacion;
        private readonly IMecanicoRepositorio _repoMecanico;
        private readonly IEstadoRepositorio _repoEstado;
        private readonly IVehiculoRepositorio _repoVehiculo;
        public ReparacionController(IReparacionRepositorio repoReparacion, IMecanicoRepositorio repoMecanico,
            IEstadoRepositorio repoEstado, IVehiculoRepositorio repoVehiculo)
        {
            _repoReparacion = repoReparacion;
            _repoMecanico = repoMecanico;
            _repoEstado = repoEstado;
            _repoVehiculo = repoVehiculo;
        }
        public IActionResult Index()
        {
            ReparacionVM vm = new()
            {
                Reparaciones = _repoReparacion.ObtenerTodos(incluirPropiedades: "Vehiculo, HojaIngreso, " +
                "Progreso, InformeFinal, Mecanico, Estado")
            };
            return View(vm);
        }
        public IActionResult Guardar()
        {
            ReparacionVM vm = new()
            {
                Mecanicos = _repoMecanico.ObtenerTodos(),
                Vehiculos = _repoVehiculo.ObtenerTodos(incluirPropiedades: "Usuario"),
                Estados = _repoEstado.ObtenerTodos()
            };
            return View(vm);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Guardar(ReparacionVM vm)
        {
            Reparacion reparacion = new Reparacion()
            {
                FechaSolicitada = vm.FechaSolicitada,
                IdAuto = vm.IdAuto,
                IdHojaIngreso = vm.IdHojaIngreso,
                IdProgreso = vm.IdProgreso,
                IdInforme = vm.IdInforme,
                IdMecanico = vm.IdMecanico,
                IdEstado = vm.IdEstado
            };
            _repoReparacion.Agregar(reparacion);
            return RedirectToAction("Index");
        }
        public IActionResult Editar(int id)
        {
            Reparacion rep = _repoReparacion.Obtener(id);
            ReparacionVM vm = new()
            {
                Id = rep.Id,
                FechaSolicitada = rep.FechaSolicitada,
                Vehiculo = rep.Vehiculo,
                HojaIngreso = rep.HojaIngreso,
                Progreso = rep.Progreso,
                InformeFinal = rep.InformeFinal,
                Mecanico = rep.Mecanico,
                Estado = rep.Estado,
                Mecanicos = _repoMecanico.ObtenerTodos(),
                Vehiculos = _repoVehiculo.ObtenerTodos(incluirPropiedades: "Usuario"),
                Estados = _repoEstado.ObtenerTodos()
            };
            return View(vm);
        }
        [HttpPost]
        public IActionResult Editar(ReparacionVM vm)
        {
            Reparacion reparacion = new Reparacion()
            {
                Id = vm.Id,
                FechaSolicitada = vm.FechaSolicitada,
                IdAuto = vm.IdAuto,
                IdHojaIngreso = vm.IdHojaIngreso,
                IdProgreso = vm.IdProgreso,
                IdInforme = vm.IdInforme,
                IdMecanico = vm.IdMecanico,
                IdEstado = vm.IdEstado
            };
            _repoReparacion.Actualizar(reparacion);
            return RedirectToAction("Index");
        }
    }
}
