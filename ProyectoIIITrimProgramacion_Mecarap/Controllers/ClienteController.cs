﻿using Microsoft.AspNetCore.Mvc;
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

        public ClienteController(IClienteRepositorio repoCliente, IWebHostEnvironment webHostEnvironment, ApplicationDbContext db)
        {
            _repoCliente = repoCliente;
            _webHostEnvironment = webHostEnvironment;
            _db = db;
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
                _db.Add(cliente);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        public IActionResult Editar(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cliente cliente = _repoCliente.Obtener(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Update(cliente);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

    }
}