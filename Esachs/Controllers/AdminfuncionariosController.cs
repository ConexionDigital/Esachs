using achsservicios.Entities;
using achsservicios.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace achsservicios.Controllers
{
    public class AdminfuncionariosController : Controller
    {
        private readonly ILogger<AdminfuncionariosController> _logger;
        private readonly ApplicationDbContext _context;

        public AdminfuncionariosController(ILogger<AdminfuncionariosController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var adminFuncionarios = new AdminFuncViewModel
            {
                Funcionarios = _context.Funcionarios
                                    .Include(f => f.Ceco)
                                    .Include(f => f.Cargo)
                                    .Include(f => f.Uniforme)
            };
            return View(adminFuncionarios);
        }

        public IActionResult EditarFuncionario(int id)
        {
            var adminFuncionarios = new FuncionarioViewModel
            {
                funcionario = _context.Funcionarios
                                .Include(f => f.Cargo)
                                .Include(f => f.Ceco)
                                .Include(f => f.Uniforme)
                                .FirstOrDefault(f => f.Rut == id),
                ceco = _context.Ceco.ToList(),
                cargo = _context.Cargos.ToList(),
                uniforme = _context.Uniformes.ToList()
            };

            return View(adminFuncionarios);
        }

        [HttpPost]
        public IActionResult EditarFuncionario(FuncionarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                var funcionarioActualizar = _context.Funcionarios
                                                    .FirstOrDefault(f => f.Rut == model.funcionario.Rut);

                if (funcionarioActualizar != null)
                    // agregar el modelo correcto
                {
                    funcionarioActualizar.Nombre = model.funcionario.Nombre;
                    funcionarioActualizar.Telefono = model.funcionario.Telefono;
                    funcionarioActualizar.Correo = model.funcionario.Correo;

                    funcionarioActualizar.Cargo = model.funcionario.Cargo;
                    funcionarioActualizar.Uniforme = model.funcionario.Uniforme;
                    funcionarioActualizar.Ceco = model.funcionario.Ceco;

                    _context.Add(funcionarioActualizar);
                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "No se pudo encontrar el funcionario para actualizar.");
                }
            }

            return View(model);
        }
    }
}
