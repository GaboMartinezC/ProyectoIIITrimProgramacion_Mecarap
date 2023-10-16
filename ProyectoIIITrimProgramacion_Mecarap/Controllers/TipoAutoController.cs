using Microsoft.AspNetCore.Mvc;
using ProyectoIIITrimProgramacion_Mecarap.Datos;
using ProyectoIIITrimProgramacion_Mecarap.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ProyectoIIITrimProgramacion_Mecarap.Controllers
{
    public class TipoAutoController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public TipoAutoController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            IEnumerable<TipoAuto> lista = _db.TiposAuto;
            return View(lista);
        }
        public IActionResult Guardar()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Guardar(TipoAuto tipoAuto)
        {
            if (ModelState.IsValid)
            {
                //Recibo un archivo que proviene del formulario html
                var files = HttpContext.Request.Form.Files;
                //Guarda en la string la ubicacion donde se guardará la imagen
                string webRootPath = _webHostEnvironment.WebRootPath;
                //archivo + ruta
                string upload = webRootPath + WC.ImagenRuta;
                //asigna un id unico a la imagen
                string fileName = Guid.NewGuid().ToString();
                //le asigna una extensión al archivo
                string extension = Path.GetExtension(files[0].FileName);
                using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                tipoAuto.ImgUrl = fileName + extension;
                _db.TiposAuto.Add(tipoAuto);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Vehiculo? vehiculo = _db.Vehiculos.Find(id);
            return View(vehiculo);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Editar(TipoAuto tipoAuto)
        {
            if (ModelState.IsValid)
            {
                //Recibo un archivo que proviene del formulario html
                var files = HttpContext.Request.Form.Files;
                //Guarda en la string la ubicacion donde se guardará la imagen
                string webRootPath = _webHostEnvironment.WebRootPath;
                //archivo + ruta
                string upload = webRootPath + WC.ImagenRuta;
                //asigna un id unico a la imagen
                string fileName = Guid.NewGuid().ToString();
                //le asigna una extensión al archivo
                string extension = Path.GetExtension(files[0].FileName);
                using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                tipoAuto.ImgUrl = fileName + extension;
                _db.TiposAuto.Add(tipoAuto);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Eliminar()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Eliminar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Vehiculo? vehiculo = _db.Vehiculos.Find(id);
            vehiculo.Borrado = true;
            _db.Update(vehiculo);
            _db.SaveChanges();
            return View();
        }
    }
}
