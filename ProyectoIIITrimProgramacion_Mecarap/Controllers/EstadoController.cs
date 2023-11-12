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
            //Recibo un archivo que proviene del formulario html
            var files = HttpContext.Request.Form.Files;
            if (files.Count == 1)
            {
                estado.Borrado = false;
                //verifica que no hayan dos tipo autos iguales
                var dbSet = _db.Estados;
                _db.Estados.Add(estado);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View();
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
            if (ModelState.IsValid)
            {
                _db.Estados.Add(estado);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
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
        /*[ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Eliminar(Estado? estado)
        {
            if (estado.Id == null || estado.Id == 0)
            {
                return NotFound();
            }
            Estado estado = _db.Estados.Find(estado.Id);
            estado.Borrado = true;
            _db.Update(estado);
            _db.SaveChanges();
            return View();
        }*/
    }
}
