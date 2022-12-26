using Microsoft.AspNetCore.Mvc;

namespace Sanatorium.UI.Controllers
{
    public class AdministratorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
