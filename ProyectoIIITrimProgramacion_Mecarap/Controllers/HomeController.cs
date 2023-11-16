using Microsoft.AspNetCore.Mvc;
using ProyectoIIITrimProgramacion_Mecarap.Models;
using System.Diagnostics;
using ProyectoIIITrimProgramacion_Mecarap.Models.ViewModels;
using ProyectoIIITrimProgramacion_Mecarap.Datos.Repositorio.IRepositorio;

namespace ProyectoIIITrimProgramacion_Mecarap.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IReparacionRepositorio _repoReparacion;
        private readonly IVehiculoRepositorio _repoVehiculo;
        private readonly IMecanicoRepositorio _repoMecanico;
        private readonly IEstadoRepositorio _repoEstado;
        public HomeController(ILogger<HomeController> logger, IEstadoRepositorio repoEstado, IReparacionRepositorio repoReparacion, IMecanicoRepositorio repoMecanico, IVehiculoRepositorio repoVehiculo)
        {
            _logger = logger;
            _repoReparacion = repoReparacion;
            _repoVehiculo = repoVehiculo;
            _repoMecanico = repoMecanico;
            _repoEstado = repoEstado;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult HomeCliente()
        {
            ReparacionVM reparacion = new()
            {
                Vehiculos = _repoVehiculo.ObtenerTodos()
            };
            return View(reparacion);
        }
        public IActionResult HomeMecanico()
        {
            IEnumerable<Reparacion> lista = _repoReparacion.ObtenerTodos();
            return View(lista);
        }
    }
}