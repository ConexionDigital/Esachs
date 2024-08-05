using achsservicios;
using achsservicios.Models;
using achsservicios.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace achsservicios.Controllers
{
    public class IngresoController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;
        public IngresoController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
        }

        public IActionResult Index(string returnURL = null)
        {
            ViewData["ReturnUrl"] = returnURL;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(AccesoViewModel acceso, string returnURL = null)
        {
            ViewData["ReturnUrl"] = returnURL;
            returnURL ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                var resultado = await _signInManager.PasswordSignInAsync(acceso.Email, acceso.Password, acceso.RememberMe, lockoutOnFailure: false);

                if (resultado.Succeeded)
                {
                    return LocalRedirect("~/Reportes");
                }
                else
                {
                    if (resultado.IsLockedOut)
                    {
                        return View("Bloqueado");
                    }
                    ModelState.AddModelError(string.Empty, "Usuario o contraseña equivocados");
                    return View(acceso);
                }
            }

            return View(acceso);

        }


        [HttpGet]
        public async Task<IActionResult> Crear()
        {
            RegistroViewModel registro = new();
            return View(registro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(RegistroViewModel registro, string returnURL = null)
        {
            ViewData["ReturnUrl"] = returnURL;
            returnURL ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                var usuario = new Usuario
                {
                    UserName = registro.Email,
                    Nombre = registro.Nombre,
                    Email = registro.Email
                };
                var resultado = await _userManager.CreateAsync(usuario, registro.Password);

                if (resultado.Succeeded)
                {
                    await _signInManager.SignInAsync(usuario, isPersistent: false);

                    return LocalRedirect(returnURL);
                }

                ValidarErrores(resultado);
            }

            return View(registro);

        }


        // Manejador de Errores
        private void ValidarErrores(IdentityResult resultado)
        {
            foreach (var error in resultado.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}
