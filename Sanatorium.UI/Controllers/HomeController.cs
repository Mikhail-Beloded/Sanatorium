using Microsoft.AspNetCore.Mvc;
using Sanatorium.BLL.IServices;
using Sanatorium.DAL.Paging;
using Sanatorium.UI.Models;
using System.Diagnostics;

namespace Sanatorium.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IPatientService _patientService;

        private PageParameters pageParameters = new();

        public HomeController(ILogger<HomeController> logger, IPatientService patientService)
        {
            _logger = logger;
            _patientService = patientService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> PatientsMain(CancellationToken cancellationToken)
        {
            var dtos = await _patientService.GetPagePatientAsync(pageParameters, cancellationToken);
            return View(dtos);
        }

        public IActionResult AddPatient()
        {
            return View();
        }

        public async Task<IActionResult> DeletePatient(int id, CancellationToken cancellationToken)
        {
            await _patientService.RemovePateintAsync(id, cancellationToken);
            return RedirectToAction("PatientsMain");
        }
    }
}