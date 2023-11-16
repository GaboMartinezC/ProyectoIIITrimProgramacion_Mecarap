using Microsoft.AspNetCore.Mvc;
using ProyectoIIITrimProgramacion_Mecarap.Datos.Repositorio.IRepositorio;
using ProyectoIIITrimProgramacion_Mecarap.Models;
using ProyectoIIITrimProgramacion_Mecarap.Models.ViewModels;

namespace ProyectoIIITrimProgramacion_Mecarap.Controllers
{
    public class VehiculoController : Controller
    {
        private readonly ITipoAutoRepositorio _repoTipoAuto;
        private readonly IClienteRepositorio _repoCliente;
        private readonly IVehiculoRepositorio _repoVehiculo;
        public VehiculoController(ITipoAutoRepositorio repoTipoAuto, IClienteRepositorio repoCliente, IVehiculoRepositorio repoVehiculo)
        {
            _repoTipoAuto = repoTipoAuto; 
            _repoCliente = repoCliente;
            _repoVehiculo = repoVehiculo;
        }
        public IActionResult Index()
        {
            IEnumerable<Vehiculo> lista = _repoVehiculo.ObtenerTodos(incluirPropiedades: "Usuario,TipoAuto");
            return View(lista);
        }
        public IActionResult Guardar()
        {
            VehiculoVM vm = new();
            vm.tiposAuto = _repoTipoAuto.ObtenerTodos();
            vm.clientes = _repoCliente.ObtenerTodos();
            return View(vm);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Guardar(VehiculoVM vm)
        {
            IEnumerable<Vehiculo> dbset = _repoVehiculo.ObtenerTodos();
            if (vm.Descripcion == null || vm.Modelo == null)
                return RedirectToAction("Index");
            else
            {
                foreach (var auto in dbset)
                {
                    if (auto.Descripcion == vm.Descripcion.Trim())
                    {
                        if (!auto.Borrado)
                        {
                            vm.tiposAuto = _repoTipoAuto.ObtenerTodos();
                            vm.clientes = _repoCliente.ObtenerTodos();
                            return View(vm);
                        }
                    }
                }
                Vehiculo vehiculo = new Vehiculo()
                {
                    Descripcion = vm.Descripcion.Trim(),
                    Modelo = vm.Modelo.Trim(),
                    IdPropietario = vm.IdPropietario,
                    IdTipoAuto = vm.IdTipoAuto,
                    Borrado = false
                };
                _repoVehiculo.Agregar(vehiculo);
                _repoVehiculo.Grabar();
                return RedirectToAction("Index");
            }

        }
        public IActionResult Editar(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            Vehiculo? vehiculo = _repoVehiculo.Obtener(id);
            VehiculoVM vm = new()
            {
                Descripcion = vehiculo.Descripcion,
                Modelo = vehiculo.Modelo,
                IdPropietario = vehiculo.IdPropietario,
                IdTipoAuto = vehiculo.IdTipoAuto,
                Borrado = false,
                tiposAuto = _repoTipoAuto.ObtenerTodos(),
                clientes = _repoCliente.ObtenerTodos()
            };
            return View(vm);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Editar(VehiculoVM vm)
        {
            if (vm.Descripcion == null || vm.Modelo == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                Vehiculo vehiculo = new()
                {
                    Id = vm.Id,
                    Descripcion = vm.Descripcion,
                    Modelo = vm.Modelo,
                    IdTipoAuto = vm.IdTipoAuto,
                    IdPropietario = vm.IdPropietario,
                    Borrado = false
                };
                _repoVehiculo.Actualizar(vehiculo);
                _repoVehiculo.Grabar();
                return RedirectToAction("Index");
            }
        }
        public IActionResult Eliminar(int id)
        {
            Vehiculo? vehiculo = _repoVehiculo.Obtener(id);
            vehiculo.Usuario = _repoCliente.Obtener(vehiculo.IdPropietario);
            vehiculo.TipoAuto = _repoTipoAuto.Obtener(vehiculo.IdTipoAuto);
            return View(vehiculo);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Eliminar(Vehiculo vehiculo)
        {
            Vehiculo? vec = _repoVehiculo.Obtener(vehiculo.Id);
            vec.Borrado = true;
            _repoVehiculo.Actualizar(vec);
            _repoVehiculo.Grabar();
            return RedirectToAction("Index");
        }
    }
}
