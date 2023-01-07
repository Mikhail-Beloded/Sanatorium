using Microsoft.AspNetCore.Mvc;

namespace Sanatorium.UI.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
