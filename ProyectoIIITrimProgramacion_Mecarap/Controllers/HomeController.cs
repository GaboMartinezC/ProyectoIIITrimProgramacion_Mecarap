using Microsoft.AspNetCore.Mvc;
using ProyectoIIITrimProgramacion_Mecarap.Models;
using System.Diagnostics;
using ProyectoIIITrimProgramacion_Mecarap.Models.ViewModels;
using ProyectoIIITrimProgramacion_Mecarap.Datos.Repositorio.IRepositorio;
using Models.ViewModels;

namespace ProyectoIIITrimProgramacion_Mecarap.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IReparacionRepositorio _repoReparacion;
        private readonly IVehiculoRepositorio _repoVehiculo;
        private readonly IMecanicoRepositorio _repoMecanico;
        private readonly IEstadoRepositorio _repoEstado;
        private readonly IClienteRepositorio _repoCliente;
        public HomeController(ILogger<HomeController> logger, IEstadoRepositorio repoEstado, IReparacionRepositorio repoReparacion, IMecanicoRepositorio repoMecanico,
            IVehiculoRepositorio repoVehiculo, IClienteRepositorio repoCliente)
        {
            _logger = logger;
            _repoReparacion = repoReparacion;
            _repoVehiculo = repoVehiculo;
            _repoMecanico = repoMecanico;
            _repoCliente = repoCliente;
            _repoEstado = repoEstado;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(UsuarioVM usuario)
        {
            IEnumerable<Mecanico> mecanicos = _repoMecanico.ObtenerTodos();
            foreach (var mecanico in mecanicos)
            {
                if (mecanico.Nombre == usuario.nombre && mecanico.Pass == usuario.pass)
                {
                    WC.usuarioActivo = usuario;
                    return RedirectToAction("HomeMecanico");
                }
                    
            }
            IEnumerable<Cliente> clientes = _repoCliente.ObtenerTodos();
            foreach (var cliente in clientes)
            {
                if (cliente.Nombre == usuario.nombre && cliente.Pass == usuario.pass)
                {
                    WC.usuarioActivo = usuario;
                    return RedirectToAction("HomeCliente");
                }
            }
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
            ReparacionVM lista = new()
            {
                Reparaciones = _repoReparacion.ObtenerTodos(),
                Mecanicos = _repoMecanico.ObtenerTodos(),
                Vehiculos = _repoVehiculo.ObtenerTodos(),
                Estados = _repoEstado.ObtenerTodos()
            };
            return View(lista);
        }
        public IActionResult HomeMecanico()
        {
            IEnumerable<Reparacion> lista = _repoReparacion.ObtenerTodos(incluirPropiedades: "Vehiculo,Mecanico,Estado");
            return View(lista);
        }
    }
}