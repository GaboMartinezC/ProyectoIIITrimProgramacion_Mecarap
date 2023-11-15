using Microsoft.AspNetCore.Mvc;
using ProyectoIIITrimProgramacion_Mecarap.Datos.Repositorio.IRepositorio;
using ProyectoIIITrimProgramacion_Mecarap.Models;

namespace ProyectoIIITrimProgramacion_Mecarap.Controllers
{
    public class TipoAutoController : Controller
    {
        private readonly ITipoAutoRepositorio _repoTipoAuto; 
        private readonly IWebHostEnvironment _webHostEnvironment;
        public TipoAutoController(ITipoAutoRepositorio repoTipoAuto, IWebHostEnvironment webHostEnvironment)
        {
            _repoTipoAuto = repoTipoAuto;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            IEnumerable<TipoAuto> lista = _repoTipoAuto.ObtenerTodos();
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
                var dbSet = _repoTipoAuto.ObtenerTodos();
                foreach (var tipo in dbSet)
                {
                    if (tipo.Descripcion == tipoAuto.Descripcion || tipo.ImgUrl == tipoAuto.Descripcion)
                        return View();
                }
                _repoTipoAuto.Agregar(tipoAuto);
                _repoTipoAuto.Grabar();
                return RedirectToAction("Index");
            }
            else
                return View();
        }
        public IActionResult Editar(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            TipoAuto tipoAuto = _repoTipoAuto.Obtener(id);
            return View(tipoAuto);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        //fixme
        public IActionResult Editar(TipoAuto tipoAuto)
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
            _repoTipoAuto.Actualizar(tipoAuto);
            _repoTipoAuto.Grabar();
            return RedirectToAction("Index");
        }
        public IActionResult Eliminar(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            TipoAuto tipo = _repoTipoAuto.Obtener(id);
            return View(tipo);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Eliminar(TipoAuto tipo)
        {
            if (tipo.Id == null || tipo.Id == 0)
            {
                return NotFound();
            }
            TipoAuto? tipoVehiculo = _repoTipoAuto.Obtener(tipo.Id);
            tipoVehiculo.Borrado = true;
            _repoTipoAuto.Actualizar(tipoVehiculo);
            _repoTipoAuto.Grabar();
            return RedirectToAction("Index");
        }
    }
}
