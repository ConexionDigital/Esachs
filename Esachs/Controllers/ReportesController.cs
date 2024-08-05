using achsservicios;
using achsservicios.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace achsservicios.Controllers
{
    public class ReportesController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly ApplicationDbContext context;

        public ReportesController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            var tallasTomadas = context.Funcionarios.Where(f => f.TallaTomada).Count();
            var totalFuncionarios = context.Funcionarios.Count();
            var funcionarios = context.Funcionarios
                                    .Include(f => f.Uniforme)
                                    .Include(f => f.Ceco);

            var reporteModel = new ReporteViewModel
            {
                TallasTomadas = tallasTomadas,
                FuncionariosTotales = totalFuncionarios,
                Funcionarios = funcionarios
            };

            return View(reporteModel);
        }
    }
}
