using Microsoft.AspNetCore.Mvc;

namespace achsservicios.Controllers
{
    public class PortalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
