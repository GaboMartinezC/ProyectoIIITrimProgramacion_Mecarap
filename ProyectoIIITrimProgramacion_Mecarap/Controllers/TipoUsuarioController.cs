using Microsoft.AspNetCore.Mvc;
using ProyectoIIITrimProgramacion_Mecarap.Datos;
using ProyectoIIITrimProgramacion_Mecarap.Datos.Repositorio.IRepositorio;
using ProyectoIIITrimProgramacion_Mecarap.Models;

namespace ProyectoIIITrimProgramacion_Mecarap.Controllers
{
    public class TipoUsuarioController : Controller
    {
        private readonly ITipoUsuarioRepositorio _repoTipoUsuario;
        public TipoUsuarioController(ITipoUsuarioRepositorio repoTipoUsuario)
        {
            _repoTipoUsuario = repoTipoUsuario;
        }

        public IActionResult Index()
        {
            IEnumerable<TipoUsuario> lista = _repoTipoUsuario.ObtenerTodos();
            return View(lista);
        }

        public IActionResult Guardar()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Guardar(TipoUsuario tipoUsuario)
        {
            tipoUsuario.Borrado = false;
            var dbSet = _repoTipoUsuario.ObtenerTodos();
            foreach (var e in dbSet)
            {
                if (tipoUsuario.Descripcion == e.Descripcion)
                    return View();
            }
            _repoTipoUsuario.Agregar(tipoUsuario);
            _repoTipoUsuario.Grabar();
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            TipoUsuario tipoUsuario = _repoTipoUsuario.Obtener(id);
            return View(tipoUsuario);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Editar(TipoUsuario tipoUsuario)
        {
            _repoTipoUsuario.Actualizar(tipoUsuario);
            _repoTipoUsuario.Grabar();
            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            TipoUsuario tipoUsuario = _repoTipoUsuario.Obtener(id);
            return View(tipoUsuario);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Eliminar(TipoUsuario tipoUsuario)
        {
            TipoUsuario? tpu = _repoTipoUsuario.Obtener(tipoUsuario.Id);
            tpu.Borrado = true;
            _repoTipoUsuario.Actualizar(tpu);
            _repoTipoUsuario.Grabar();
            return RedirectToAction("Index");
        }
    }
}