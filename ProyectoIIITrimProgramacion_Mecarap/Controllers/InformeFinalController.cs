using Microsoft.AspNetCore.Mvc;
using ProyectoIIITrimProgramacion_Mecarap.Datos;
using ProyectoIIITrimProgramacion_Mecarap.Models;
using ProyectoIIITrimProgramacion_Mecarap.Datos.Repositorio.IRepositorio;

namespace ProyectoIIITrimProgramacion_Mecarap.Controllers
{
    public class InformeFinalController : Controller
    {
        private readonly IInformeFinalRepositorio _repoInformeFinal;

        public InformeFinalController(IInformeFinalRepositorio repoInformeFinal)
        {
            _repoInformeFinal = repoInformeFinal;
        }

        public IActionResult Index()
        {
            IEnumerable<InformeFinal> lista = _repoInformeFinal.ObtenerTodos();
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
            var dbSet = _repoInformeFinal.ObtenerTodos();
            foreach (var i in dbSet)
            {
                if (informe.Descripcion == i.Descripcion)
                {
                    return View(i);
                }
            }
            _repoInformeFinal.Agregar(informe);
            _repoInformeFinal.Grabar();
            return RedirectToAction("Index");
        }
        public IActionResult Editar(int id)
        {
            //comprobamos que el id enviado no sea ni cero ni nulo
            if (id == 0)
            {
                return NotFound();
            }
            //buscamos el id que corresponda al enviado
            InformeFinal informe = _repoInformeFinal.Obtener(id);
            return View(informe);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Editar(InformeFinal informe)
        {
            _repoInformeFinal.Actualizar(informe);
            _repoInformeFinal.Grabar();
            return RedirectToAction("Index");
        }
        public IActionResult Eliminar(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            InformeFinal informe = _repoInformeFinal.Obtener(id);
            return View(informe);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Eliminar(InformeFinal informe)
        {
            InformeFinal? est = _repoInformeFinal.Obtener(informe.Id);
            est.Estado = true;
            _repoInformeFinal.Actualizar(est);
            _repoInformeFinal.Grabar();
            return RedirectToAction("Index");

        }

    }
}