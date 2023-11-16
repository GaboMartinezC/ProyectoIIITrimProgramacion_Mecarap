using Microsoft.AspNetCore.Mvc;
using ProyectoIIITrimProgramacion_Mecarap.Datos;
using ProyectoIIITrimProgramacion_Mecarap.Datos.Repositorio.IRepositorio;
using ProyectoIIITrimProgramacion_Mecarap.Models;

namespace ProyectoIIITrimProgramacion_Mecarap.Controllers
{
    public class ProgresoController : Controller
    {
        private readonly IProgresoRepositorio _repoProgreso;
        public ProgresoController(IProgresoRepositorio repoProgreso)
        {
            _repoProgreso = repoProgreso;
        }

        public IActionResult Index()
        {
            IEnumerable<Progreso> lista = _repoProgreso.ObtenerTodos();
            return View(lista);
        }

        public IActionResult Guardar()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Guardar(Progreso progreso)
        {
            progreso.Borrado = false;
            var dbSet = _repoProgreso.ObtenerTodos();
            foreach (var p in dbSet)
            {
                if (progreso.Descripcion == p.Descripcion)
                    return View();
            }
            _repoProgreso.Agregar(progreso);
            _repoProgreso.Grabar();
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            Progreso progreso = _repoProgreso.Obtener(id);
            return View(progreso);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Editar(Progreso progreso)
        {
            _repoProgreso.Actualizar(progreso);
            _repoProgreso.Grabar();
            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            Progreso? progreso = _repoProgreso.Obtener(id);
            return View(progreso);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Eliminar(Progreso progreso)
        {
            Progreso? pgr = _repoProgreso.Obtener(progreso.Id);
            pgr.Borrado = true;
            _repoProgreso.Actualizar(progreso);
            _repoProgreso.Grabar();
            return RedirectToAction("Index");
        }
    }
}