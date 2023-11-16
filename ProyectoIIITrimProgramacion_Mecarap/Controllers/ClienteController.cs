using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoIIITrimProgramacion_Mecarap.Datos;
using ProyectoIIITrimProgramacion_Mecarap.Datos.Repositorio.IRepositorio;
using ProyectoIIITrimProgramacion_Mecarap.Models;
using ProyectoIIITrimProgramacion_Mecarap.Models.ViewModels;
namespace ProyectoIIITrimProgramacion_Mecarap.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepositorio _repoCliente;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ApplicationDbContext _db;

        public ClienteController(IClienteRepositorio repoCliente, IWebHostEnvironment webHostEnvironment)
        {
            _repoCliente = repoCliente;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            IEnumerable<Cliente> lista = _repoCliente.ObtenerTodos(incluirPropiedades: "Cliente");
            return View(lista);

        }

        public IActionResult Guardar()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Guardar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _repoCliente.Agregar(cliente);
                _repoCliente.Grabar();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        public IActionResult Editar(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Cliente cliente= _repoCliente.Obtener(id);
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, Cliente cliente)
        {
            _repoCliente.Actualizar(cliente);
            _repoCliente.Grabar();
            return RedirectToAction("Index");
        }

    }
}