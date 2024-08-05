using achsservicios;
using achsservicios.Entities;
using achsservicios.Models;
using achsservicios.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Diagnostics;

namespace achsservicios.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly ApplicationDbContext context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.logger = logger;
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(AccesoFuncViewModel modelo)
        {
            var rutDv = modelo.Rut.Split('-');
            var funcionarios = context.Funcionarios;

            var existeFuncionario = funcionarios.Any(f =>
                f.Rut == int.Parse(rutDv[0]) &&
                f.Dv == char.Parse(rutDv[1]) &&
                f.Clave == modelo.Clave);

            HttpContext.Session.SetString("rutFunc", rutDv[0]);

            if (existeFuncionario)
            {
                var estado = funcionarios.FirstOrDefault(f => f.Rut == int.Parse(rutDv[0])).Estado;

                if (estado)
                {
                    if(funcionarios.FirstOrDefault(f => f.Rut == int.Parse(rutDv[0])).TallaTomada)
                    {
                        return RedirectToAction("ConfRecepcion");
                    }
                    else
                    {
                        return RedirectToAction("Tallas");
                    }
                }
                else
                {
                    return View(modelo);
                }
            }
            else
            {
                return View(modelo);
            }
        }

        public IActionResult Tallas()
        {
            int rut = 0;

            var TomaTalla = new TomaTallaViewModel();

            try
            {
                rut = int.Parse(HttpContext.Session.GetString("rutFunc"));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                return RedirectToAction("Index");
            }

            var funcionarioBD = context.Funcionarios
                .Include(f => f.Uniforme)
                    .ThenInclude(f => f.Prendas)
                        .ThenInclude(f => f.PrendasTallas)
                            .ThenInclude(f => f.Talla)
                .Include(f => f.Cargo)
                .Include(f => f.Ceco)
                .FirstOrDefault(f => f.Rut == rut);

            if (funcionarioBD.TallaTomada)
            {
                var detPedido = context.DetPedidos.Where(d =>
                    d.CabPedidos.IdSolicitante == funcionarioBD.Rut.ToString()).ToList();
                ICollection<PrendasViewModel> prendasSolicitadas = [];

                foreach (var pedido in detPedido)
                {
                    var prenda = context.PrendasTallas.FirstOrDefault(p => p.CodProducto == pedido.CodPrenda);

                    var agregarPrenda = new PrendasViewModel
                    {
                        CodPrenda = prenda.CodProducto,
                        DescPrenda = context.Prendas.FirstOrDefault(dp => dp.Id == prenda.PrendaId).Descripcion,
                        DescTalla = context.Tallas.FirstOrDefault(dt => dt.Id == prenda.TallaId).Descripcion
                    };

                    prendasSolicitadas.Add(agregarPrenda);
                };

                TomaTalla = new TomaTallaViewModel
                {
                    Funcionario = funcionarioBD,
                    Prendas = prendasSolicitadas
                };
            }
            else
            {
                TomaTalla = new TomaTallaViewModel
                {
                    Funcionario = funcionarioBD
                };
            }


            return View(TomaTalla);
        }

        [HttpPost]
        public IActionResult Tallas(TomaTallaViewModel model)
        {

            var funcionarioActualizar = context.Funcionarios.FirstOrDefault(f => f.Rut == model.Funcionario.Rut);
            funcionarioActualizar.TallaTomada = true;

            if (model.Funcionario.Correo.Length > 0)
            {
                funcionarioActualizar.Correo = model.Funcionario.Correo;
            }

            if (model.Funcionario.Telefono is not null)
            {
                funcionarioActualizar.Telefono = model.Funcionario.Telefono;
            }
            
            var cabecera_pedido = new CabPedidos
            {
                IdSolicitante = model.Funcionario.Rut.ToString(),
                FechaSolicitud = DateTime.Now,
                Estado = 1,
                DetPedidos = new HashSet<DetPedidos>()
            };

            var prendas = model.Prendas;
            var prendasBD = context.Prendas;
            var pt = context.PrendasTallas;

            foreach (var p in prendas)
            {
                var precio = pt.FirstOrDefault(pt => pt.CodProducto == p.CodPrenda).Precio;
                var cantidad = prendasBD.FirstOrDefault(x => x.Id == pt.FirstOrDefault(y => y.CodProducto == p.CodPrenda).PrendaId).Cantidad;

                try
                {
                    cabecera_pedido.DetPedidos.Add
                    (
                        new DetPedidos
                        {
                            CodPrenda = p.CodPrenda,
                            Cantidad = cantidad,
                            PrecioUnitario = precio,
                            Total = cantidad * precio
                        }
                    );
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
            }

            context.Add(cabecera_pedido);

            context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ConfRecepcion()
        {
            int rut = 0;

            try
            {
                rut = int.Parse(HttpContext.Session.GetString("rutFunc"));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                return RedirectToAction("Index");
            }

            var funcionarioBD = context.Funcionarios
                .Include(f => f.Cargo)
                .FirstOrDefault(f => f.Rut == rut);

            var model = new TomaTallaViewModel
            {
                Funcionario = funcionarioBD
            };

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
