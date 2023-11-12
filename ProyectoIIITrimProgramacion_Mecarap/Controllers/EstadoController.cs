using Microsoft.AspNetCore.Mvc;
using ProyectoIIITrimProgramacion_Mecarap.Datos;
using ProyectoIIITrimProgramacion_Mecarap.Models;

namespace ProyectoIIITrimProgramacion_Mecarap.Controllers
{
    public class EstadoController : Controller
    {
        private readonly ApplicationDbContext _db;
        public EstadoController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Estado> lista = _db.Estados;
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
            var dbSet = _db.Estados;
            foreach (var e in dbSet)
            {
                if (estado.Descripcion == e.Descripcion)
                    return View();
            }
            _db.Estados.Add(estado);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Estado estado = _db.Estados.Find(id);
            return View(estado);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        //fixme
        public IActionResult Editar(Estado estado)
        {
            _db.Estados.Update(estado);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Eliminar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Estado estado = _db.Estados.Find(id);
            return View(estado);
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Eliminar(Estado estado)
        {
            Estado? est = _db.Estados.Find(estado.Id);
            est.Borrado = true;
            _db.Update(est);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
