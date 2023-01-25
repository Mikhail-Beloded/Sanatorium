using Microsoft.AspNetCore.Mvc;
using Sanatorium.BLL.IServices;
using Sanatorium.DAL.Repositories;

namespace Sanatorium.UI.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IVoucherService _voucherService;

        public DoctorController(IVoucherService voucherService)
        {
            _voucherService= voucherService;
        }

        public IActionResult Index()
        {
            return View();
        }       
    }
}
