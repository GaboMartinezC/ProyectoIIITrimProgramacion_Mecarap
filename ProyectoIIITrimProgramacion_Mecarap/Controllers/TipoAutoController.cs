using Microsoft.AspNetCore.Mvc;
using ProyectoIIITrimProgramacion_Mecarap.Datos;
using ProyectoIIITrimProgramacion_Mecarap.Models;

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
            //Recibo un archivo que proviene del formulario html
            var files = HttpContext.Request.Form.Files;
            if (files.Count == 1)
            {
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
                tipoAuto.Borrado = false;
                //verifica que no hayan dos tipo autos iguales
                var dbSet = _db.TiposAuto;
                foreach (var tipo in dbSet)
                {
                    if (tipo.Descripcion == tipoAuto.Descripcion || tipo.ImgUrl == tipoAuto.Descripcion)
                        return View();
                }
                _db.TiposAuto.Add(tipoAuto);
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
