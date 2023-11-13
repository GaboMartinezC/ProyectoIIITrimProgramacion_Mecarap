using Microsoft.AspNetCore.Mvc;
using ProyectoIIITrimProgramacion_Mecarap.Models;
using ProyectoIIITrimProgramacion_Mecarap.Datos.Repositorio.IRepositorio;
using ProyectoIIITrimProgramacion_Mecarap.Models.ViewModels;
using System.Data.Common;

namespace ProyectoIIITrimProgramacion_Mecarap.Controllers
{
    public class MecanicoController : Controller
    {
        public readonly IMecanicoRepositorio _repoMecanico;
        public readonly ITipoUsuarioRepositorio _repoTipoUsuario;
        public MecanicoController(IMecanicoRepositorio repoMecanico, ITipoUsuarioRepositorio repoTipoUsuario)
        {
            _repoMecanico = repoMecanico;
            _repoTipoUsuario = repoTipoUsuario;
        }
        public IActionResult Index()
        {
            //En la vista Index, el modelo es la lista de mecanicos
            IEnumerable<Mecanico> lista = _repoMecanico.ObtenerTodos();
            return View(lista);
        }
        public IActionResult Guardar()
        {
            //En la vista guardar, get y post, se utiliza el view model de mecanico
            MecanicoVM vm = new MecanicoVM()
            {
                //Datos que se muestran en la vista para los perfiles de usuario
                tiposUsuario = _repoTipoUsuario.ObtenerTodos()
            };
            return View(vm);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Guardar(MecanicoVM vm)
        {
            IEnumerable<Mecanico> lista = _repoMecanico.ObtenerTodos();
            //Valida que no hayan dos registros iguales
            foreach (var registro in lista)
            {
                if (registro.Nombre == vm.Nombre.Trim() && !(registro.Borrado))
                    return View(vm);
            }
            Mecanico mecanico = new()
            {
                Nombre = vm.Nombre,
                Pass = vm.Pass,
                IdTipoUsuario = vm.IdTipoUsuario,
                Borrado = false
            };
            _repoMecanico.Agregar(mecanico);
            _repoMecanico.Grabar();
            return RedirectToAction("Index");
        }
        public IActionResult Editar(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            Mecanico mecanico = _repoMecanico.Obtener(id);
            //Las vistas de editar, get y post, también utilizan el view model de mecanico
            MecanicoVM vm = new()
            {
                Nombre = mecanico.Nombre,
                Pass = mecanico.Pass,
                IdTipoUsuario = mecanico.IdTipoUsuario,
                Borrado = false,
                tiposUsuario = _repoTipoUsuario.ObtenerTodos()
            };
            return View(vm);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Editar(MecanicoVM vm)
        {
            Mecanico mecanico = new()
            {
                Nombre = vm.Nombre,
                Pass = vm.Pass,
                IdTipoUsuario = vm.IdTipoUsuario,
                Borrado = false
            };
            _repoMecanico.Actualizar(mecanico);
            _repoMecanico.Grabar();
            return RedirectToAction("Index");
        }
        public IActionResult Eliminar(int id)
        {
            //Las vistas de eliminar utilizan solamente el modelo de mecanico, no el VM
            Mecanico mecanico = _repoMecanico.Obtener(id);
            mecanico.TipoUsuario = _repoTipoUsuario.Obtener(mecanico.IdTipoUsuario);
            return View(mecanico);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Eliminar(Mecanico mecanico)
        {
            mecanico.Borrado = true;
            _repoMecanico.Actualizar(mecanico);
            _repoMecanico.Grabar();
            return View();
        }
    }
}
