using Microsoft.AspNetCore.Mvc;

namespace PRutCun.Controllers
{
    public class InicioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
