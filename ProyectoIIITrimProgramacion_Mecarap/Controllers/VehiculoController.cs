﻿using Microsoft.AspNetCore.Mvc;
using ProyectoIIITrimProgramacion_Mecarap.Datos;
using ProyectoIIITrimProgramacion_Mecarap.Models;
using ProyectoIIITrimProgramacion_Mecarap.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ProyectoIIITrimProgramacion_Mecarap.Controllers
{
    public class VehiculoController : Controller
    {
        private readonly ApplicationDbContext _db;
        public VehiculoController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Vehiculo> lista = _db.Vehiculos.Include(t => t.TipoAuto)
                .Include(u => u.Usuario);
            return View(lista);
        }
        public IActionResult Guardar()
        {
            VehiculoVM vm = new();
            vm.tiposAuto = _db.TiposAuto;
            vm.clientes = _db.Usuarios;
            return View(vm);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Guardar(Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                vehiculo.Borrado = false;
                _db.Vehiculos.Add(vehiculo);
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
        public IActionResult Editar(Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                _db.Vehiculos.Update(vehiculo); 
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
