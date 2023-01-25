using Microsoft.AspNetCore.Mvc;
using Sanatorium.BLL.IServices;
using System.Dynamic;

namespace Sanatorium.UI.Controllers
{
    public class ManagerController : Controller
    {
        private readonly IStatisticService _statisticService;

        public ManagerController(IStatisticService statisticService)
        {
            _statisticService= statisticService;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            dynamic model = new ExpandoObject();
            model.IllnessStatistic = await _statisticService.GetIllnessStatistic(cancellationToken);
            model.ProceduresStatistic = await _statisticService.GetProcedureStatistic(cancellationToken);
            model.NewPatientsStatistic = await _statisticService.GetNewPatientsStatistic(cancellationToken);
            model.AgePatientsStatistic = await _statisticService.GetAgeStatistic(cancellationToken);
            return View(model);
        }
    }
}
