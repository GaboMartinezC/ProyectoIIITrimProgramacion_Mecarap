using Microsoft.AspNetCore.Mvc;
using ProyectoIIITrimProgramacion_Mecarap.Datos;
using ProyectoIIITrimProgramacion_Mecarap.Models;

namespace ProyectoIIITrimProgramacion_Mecarap.Controllers
{
    public class HojaIngresoController : Controller
    {
        private readonly ApplicationDbContext _db;
        public HojaIngresoController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<HojaIngreso> lista = _db.HojasIngreso;
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
            var dbSet = _db.Estados;
            foreach (var e in dbSet)
            {
                if (hojaIngreso.Descripcion == e.Descripcion)
                    return View();
            }
            _db.HojasIngreso.Add(hojaIngreso);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            HojaIngreso hojaIngreso= _db.HojasIngreso.Find(id);
            return View(hojaIngreso);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Editar(HojaIngreso hojaIngreso)
        {
            _db.HojasIngreso.Update(hojaIngreso);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Eliminar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            HojaIngreso hojaIngreso = _db.HojasIngreso.Find(id);
            return View(hojaIngreso);
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Eliminar(HojaIngreso hojaIngreso)
        {
            HojaIngreso? hojaIN= _db.HojasIngreso.Find(hojaIngreso);
            hojaIN.Borrado = true;
            _db.Update(hojaIN);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
