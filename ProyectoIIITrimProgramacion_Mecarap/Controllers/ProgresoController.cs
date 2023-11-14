using Microsoft.AspNetCore.Mvc;
using ProyectoIIITrimProgramacion_Mecarap.Datos;
using ProyectoIIITrimProgramacion_Mecarap.Models;

namespace ProyectoIIITrimProgramacion_Mecarap.Controllers
{
    public class ProgresoController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ProgresoController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Progreso> lista = _db.Progresos;
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
            var dbSet = _db.Progresos;
            foreach (var p in dbSet)
            {
                if (progreso.Descripcion == p.Descripcion)
                    return View();
            }
            _db.Progresos.Add(progreso);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Progreso progreso = _db.Progresos.Find(id);
            return View(progreso);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        //fixme
        public IActionResult Editar(Progreso progreso)
        {
            _db.Progresos.Update(progreso);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Progreso progreso = _db.Progresos.Find(id);
            return View(progreso);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Eliminar(Progreso progreso)
        {
            Progreso? pgr = _db.Progresos.Find(progreso.Id);
            pgr.Borrado = true;
            _db.Update(pgr);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
