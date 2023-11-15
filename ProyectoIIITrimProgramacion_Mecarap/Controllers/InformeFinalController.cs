using Microsoft.AspNetCore.Mvc;
using ProyectoIIITrimProgramacion_Mecarap.Datos;
using ProyectoIIITrimProgramacion_Mecarap.Models;


namespace ProyectoIIITrimProgramacion_Mecarap.Controllers
{
    public class InformeFinalController : Controller
    {
        private readonly ApplicationDbContext _db;

        public InformeFinalController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<InformeFinal> lista = _db.InformesFinal;
            return View(lista);
        }
        public IActionResult Guardar()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Guardar(InformeFinal informe)
        {
            informe.Estado = false;
            var dbSet = _db.InformesFinal;
            foreach (var i in dbSet)
            {
                if (informe.Descripcion == i.Descripcion)
                {
                    return View(i);
                }
            }
            _db.InformesFinal.Add(informe);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Editar(int? id)
        {
            //comprobamos que el id enviado no sea ni cero ni nulo
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            //buscamos el id que corresponda al enviado
            InformeFinal informe = _db.InformesFinal.Find(id);
            return View(informe);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Editar(InformeFinal informe)
        {
            _db.InformesFinal.Update(informe);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Eliminar(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            InformeFinal informe = _db.InformesFinal.Find(id);
            return View(informe);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Eliminar(InformeFinal informe)
        {
            InformeFinal? est = _db.InformesFinal.Find(informe.Id);
            est.Estado = true;
            _db.Update(est);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}