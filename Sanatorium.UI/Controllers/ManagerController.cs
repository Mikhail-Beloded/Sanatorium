using Microsoft.AspNetCore.Mvc;

namespace Sanatorium.UI.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
