using Microsoft.AspNetCore.Mvc;
using ProyectoIIITrimProgramacion_Mecarap.Datos;
using ProyectoIIITrimProgramacion_Mecarap.Datos.Repositorio.IRepositorio;
using ProyectoIIITrimProgramacion_Mecarap.Models;

namespace ProyectoIIITrimProgramacion_Mecarap.Controllers
{
    public class HojaIngresoController : Controller
    {
        private readonly IHojaIngresoRepositorio _repoHojaRepositorio;
        public HojaIngresoController(IHojaIngresoRepositorio repoHojaRepositorio)
        {
            _repoHojaRepositorio = repoHojaRepositorio;
        }
        public IActionResult Index()
        {
            IEnumerable<HojaIngreso> lista = _repoHojaRepositorio.ObtenerTodos();
            return View(lista);
        }
        public IActionResult Guardar()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Guardar(HojaIngreso hojaIngreso)
        {
            hojaIngreso.Borrado = false;
            var dbSet = _repoHojaRepositorio.ObtenerTodos();
            foreach (var e in dbSet)
            {
                if (hojaIngreso.Descripcion == e.Descripcion)
                    return View();
            }
            _repoHojaRepositorio.Agregar(hojaIngreso);
            _repoHojaRepositorio.Grabar();
            return RedirectToAction("Index");
        }
        public IActionResult Editar(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            HojaIngreso hojaIngreso = _repoHojaRepositorio.Obtener(id);
            return View(hojaIngreso);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Editar(HojaIngreso hojaIngreso)
        {
            _repoHojaRepositorio.Actualizar(hojaIngreso);
            _repoHojaRepositorio.Grabar();
            return RedirectToAction("Index");
        }
        public IActionResult Eliminar(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            HojaIngreso hojaIngreso = _repoHojaRepositorio.Obtener(id);
            return View(hojaIngreso);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Eliminar(HojaIngreso hojaIngreso)
        {
            HojaIngreso? hojaIN = _repoHojaRepositorio.Obtener(hojaIngreso.Id);
            hojaIN.Borrado = true;
            _repoHojaRepositorio.Actualizar(hojaIN);
            _repoHojaRepositorio.Grabar();
            return RedirectToAction("Index");
        }

    }
}
