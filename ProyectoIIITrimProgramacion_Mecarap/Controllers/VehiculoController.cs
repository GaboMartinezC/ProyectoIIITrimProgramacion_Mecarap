using Microsoft.AspNetCore.Mvc;
using ProyectoIIITrimProgramacion_Mecarap.Datos;
using ProyectoIIITrimProgramacion_Mecarap.Models;
using ProyectoIIITrimProgramacion_Mecarap.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ProyectoIIITrimProgramacion_Mecarap.Controllers
{
    public class VehiculoController : Controller
    {
        private readonly ApplicationDbContext _db;
        public VehiculoController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Vehiculo> lista = _db.Vehiculos.Include(t => t.TipoAuto)
                .Include(u => u.Usuario);
            return View(lista);
        }
        public IActionResult Guardar()
        {
            VehiculoVM vm = new();
            vm.tiposAuto = _db.TiposAuto;
            vm.clientes = _db.Usuarios;
            return View(vm);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Guardar(VehiculoVM vm)
        {
            Vehiculo vehiculo = new Vehiculo();
            IEnumerable<Vehiculo> dbset = _db.Vehiculos;
            foreach (var auto in dbset)
            {
                if (auto.Descripcion == vm.Descripcion.Trim())
                {
                    if (!auto.Borrado)
                    {
                        vm.tiposAuto = _db.TiposAuto;
                        vm.clientes = _db.Usuarios;
                        vm.Notificacion = "<div class=\"alert alert-warning alert-dismissible fade show m-3 p-3\" role=\"alert\">\r\n<strong>Registro ya existente</strong> Los datos de descripcion no se pueden repetir\r\n</div>";
                        return View(vm);
                    }
                }
            }
            vehiculo.Descripcion = vm.Descripcion.Trim();
            vehiculo.Modelo = vm.Modelo.Trim();
            vehiculo.IdPropietario = vm.IdPropietario;
            vehiculo.IdTipoAuto = vm.IdTipoAuto;
            vehiculo.Borrado = false;
            _db.Vehiculos.Add(vehiculo);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Vehiculo? vehiculo = _db.Vehiculos.Find(id);
            VehiculoVM vm = new();
            vm.Descripcion = vehiculo.Descripcion;
            vm.Modelo = vehiculo.Modelo;
            vm.IdPropietario = vehiculo.IdPropietario;
            vm.IdTipoAuto = vehiculo.IdTipoAuto;
            vm.Borrado = false;
            vm.tiposAuto = _db.TiposAuto;
            vm.clientes = _db.Usuarios;
            return View(vm);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Editar(Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                //fixme
                _db.Vehiculos.Update(vehiculo); 
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Eliminar(int? id)
        {
            Vehiculo? vehiculo = _db.Vehiculos.Find(id);
            VehiculoVM vm = new();
            vm.Descripcion = vehiculo.Descripcion;
            vm.Modelo = vehiculo.Modelo;
            vm.Borrado = false;
            vm.tipoAuto = _db.TiposAuto.Find(vehiculo.IdTipoAuto).Descripcion;
            vm.cliente = _db.Usuarios.Find(vehiculo.IdPropietario).Nombre;
            return View(vm);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Eliminar(VehiculoVM vm)
        {
            Vehiculo vehiculo = _db.Vehiculos.Find(vm.Id);
            _db.Vehiculos.Remove(vehiculo);
            vehiculo.Borrado = true;
            _db.Vehiculos.Add(vm);
            return RedirectToAction("Index");
        }
    }
}
