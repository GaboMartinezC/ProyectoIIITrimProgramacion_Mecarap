using Microsoft.AspNetCore.Mvc;
using ProyectoIIITrimProgramacion_Mecarap.Datos;
using ProyectoIIITrimProgramacion_Mecarap.Datos.Repositorio.IRepositorio;
using ProyectoIIITrimProgramacion_Mecarap.Models;

namespace ProyectoIIITrimProgramacion_Mecarap.Controllers
{
    public class EstadoController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IEstadoRepositorio _repoEstado;
        public EstadoController(IEstadoRepositorio repoEstado)
        {
            _repoEstado = repoEstado;
        }
        public IActionResult Index()
        {
            IEnumerable<Estado> lista = _repoEstado.ObtenerTodos();
            return View(lista);
        }
        public IActionResult Guardar()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Guardar(Estado estado)
        {
            estado.Borrado = false;
            var dbSet = _repoEstado.ObtenerTodos();
            foreach (var e in dbSet)
            {
                if (estado.Descripcion == e.Descripcion)
                    return View();
            }
            _repoEstado.Agregar(estado);
            _repoEstado.Grabar();
            return RedirectToAction("Index");
        }
        public IActionResult Editar(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Estado estado = _repoEstado.Obtener(id);
            return View(estado);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Editar(Estado estado)
        {
            _repoEstado.Actualizar(estado);
            _repoEstado.Grabar();
            return RedirectToAction("Index");
        }
        public IActionResult Eliminar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Estado estado = _repoEstado.Obtener(id);
            return View(estado);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Eliminar(Estado estado)
        {
            Estado? est = _repoEstado.Obtener(estado.Id);
            est.Borrado = true;
            _repoEstado.Actualizar(estado);
            _repoEstado.Grabar();
            return RedirectToAction("Index");
        }
    }
}
