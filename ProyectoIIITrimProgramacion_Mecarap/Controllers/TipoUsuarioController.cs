using Microsoft.AspNetCore.Mvc;
using ProyectoIIITrimProgramacion_Mecarap.Datos;
using ProyectoIIITrimProgramacion_Mecarap.Models;

namespace ProyectoIIITrimProgramacion_Mecarap.Controllers
{
    public class TipoUsuarioController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TipoUsuarioController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<TipoUsuario> lista = _db.TiposUsuario;
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
            var dbSet = _db.TiposUsuario;
            foreach (var e in dbSet)
            {
                if (tipoUsuario.Descripcion == e.Descripcion)
                    return View();
            }
            _db.TiposUsuario.Add(tipoUsuario);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            TipoUsuario tipoUsuario = _db.TiposUsuario.Find(id);
            return View(tipoUsuario);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        //fixme
        public IActionResult Editar(TipoUsuario tipoUsuario)
        {
            _db.TipoUsuario.Update(tipoUsuario);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            TipoUsuario tipoUsuario = _db.TipoUsuario.Find(id);
            return View(tipoUsuario);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Eliminar(TipoUsuario tipoUsuario)
        {
            TipoUsuario? tpu = _db.TipoUsuario.Find(tipoUsuario.Id);
            tpu.Borrado = true;
            _db.Update(tpu);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
