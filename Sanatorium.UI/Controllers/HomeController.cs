using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sanatorium.BLL.DTOs;
using Sanatorium.BLL.IServices;
using Sanatorium.UI.Models;
using System.Diagnostics;

namespace Sanatorium.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IPatientService _patientService;

        private readonly IRoomService _roomService;

        private readonly IVoucherService _voucherService;

        private readonly IDoctorService _doctorService;

        private readonly IStatisticService _statisticService;

        private readonly IProcedureService _procedureService;

        private readonly IIllnessService _illnessService;

        private readonly IRecieptService _recieptService;

        public HomeController(ILogger<HomeController> logger, IPatientService patientService, IRoomService roomService, IVoucherService voucherService, IDoctorService doctorService, IStatisticService statisticService, IProcedureService procedureService, IIllnessService illnessService, IRecieptService recieptService)
        {
            _logger = logger;
            _patientService = patientService;
            _roomService = roomService;
            _voucherService = voucherService;
            _doctorService = doctorService;
            _statisticService = statisticService;
            _procedureService = procedureService;
            _illnessService = illnessService;
            _recieptService= recieptService;
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
            var dtos = await _patientService.GetAllPatients(cancellationToken);
            return View(dtos);
        }

        public async Task<IActionResult> ProceduresMain(CancellationToken cancellationToken)
        {
            var dtos = await _procedureService.GetAllProcedures(cancellationToken);
            return View(dtos);
        }

        public async Task<IActionResult> DoctorsMain(CancellationToken cancellationToken)
        {
            var dtos = await _doctorService.GetAllDoctors(cancellationToken);
            return View(dtos);
        }

        public async Task<IActionResult> IllnessesMain(CancellationToken cancellationToken)
        {
            var dtos = await _illnessService.GetAllIllnesses(cancellationToken);
            return View(dtos);
        }

        public async Task<IActionResult> RoomsMain(CancellationToken cancellationToken)
        {
            var dtos = await _roomService.GetAllRooms(cancellationToken);
            return View(dtos);
        }

        public async Task<IActionResult> VouchersMain(CancellationToken cancellationToken)
        {
            var dtos = await _voucherService.GetAllVouchers(cancellationToken);
            return View(dtos);
        }

        public async Task<IActionResult> RecieptsMain(CancellationToken cancellationToken)
        {
            var dtos = await _recieptService.GetAll(cancellationToken);
            return View(dtos);
        }

        public async Task<IActionResult> OldPatients(CancellationToken cancellationToken)
        {
            var dtos = await _patientService.GetAllPatients(x => x.BirthDate.AddYears(55)<DateTime.Now, cancellationToken);
            return View("PatientsMain", dtos);
        }

        public async Task<IActionResult> YoungPatients(CancellationToken cancellationToken)
        {
            var dtos = await _patientService.GetAllPatients(x => x.BirthDate.AddYears(30) >= DateTime.Now && x.BirthDate.AddYears(18) < DateTime.Now, cancellationToken);
            return View("PatientsMain", dtos);
        }

        public async Task<IActionResult> MiddlePatients(CancellationToken cancellationToken)
        {
            var dtos = await _patientService.GetAllPatients(x => x.BirthDate.AddYears(55) >= DateTime.Now && x.BirthDate.AddYears(30) < DateTime.Now, cancellationToken);
            return View("PatientsMain", dtos);
        }

        public async Task<IActionResult> OrderedPatients(CancellationToken cancellationToken)
        {
            var dtos = await _patientService.GetPatientsOrdered(cancellationToken);
            return View("PatientsMain", dtos);
        }

        public async Task<IActionResult> SubmitSearchPatient(SearchModel model, CancellationToken cancellationToken)
        {
            var dtos = await _patientService.GetAllPatients(x => x.FullName.Contains(model.Content), cancellationToken);
            return View("PatientsMain", dtos);
        }

        public async Task<IActionResult> GenerateRecieptPDF(int id, CancellationToken cancellationToken)
        {
            var pdf = await _recieptService.GeneratePdfReciept(id, cancellationToken);
            var file = new FileContentResult(pdf, "application/pdf");
            return file;
        }
       
        public IActionResult PatientsFilter()
        {
            return View();
        }

        public IActionResult SearchPatient()
        {
            return View();
        }

        public IActionResult AddPatient()
        {
            return View();
        }
      
        public IActionResult AddDoctor()
        {
            return View();
        }

        public IActionResult AddProcedure()
        {
            return View();
        }

        public IActionResult AddIllness()
        {
            return View();
        }

        public IActionResult AddRoom()
        {
            return View();
        }

        public async Task<IActionResult> AddVoucher(CancellationToken cancellationToken)
        {
            var patients = await _patientService.GetAllPatients(cancellationToken);
            var rooms = await _roomService.GetAvaliableRooms(cancellationToken);
            var illnesses = await _illnessService.GetAllIllnesses(cancellationToken);
            ViewBag.Patients = new SelectList(patients, "Id", "FullName");
            ViewBag.Rooms = new SelectList(rooms, "Id", "Id");
            ViewBag.Illnesses = new SelectList(illnesses, "Id", "Name");
            return View();
        }

        public async Task<IActionResult> AutomaticGeneration(CancellationToken cancellationToken)
        {
            var dtos = await _voucherService.GetAllVouchersWithoutDoctors(cancellationToken);
            return View(dtos);
        }

        public async Task<IActionResult> EditDoctor(int id, CancellationToken cancellationToken)
        {
            var entity = await _doctorService.GetOneDoctorAsync(id, cancellationToken);
            return View(entity);
        }

        public async Task<IActionResult> EditPatient(int id, CancellationToken cancellationToken)
        {
            var entity = await _patientService.GetOnePatientAsync(id, cancellationToken);
            return View(entity);
        }

        public async Task<IActionResult> EditProcedure(int id, CancellationToken cancellationToken)
        {
            var entity = await _procedureService.GetOneProcedureAsync(id, cancellationToken);
            return View(entity);
        }

        public async Task<IActionResult> EditIllness(int id, CancellationToken cancellationToken)
        {
            var entity = await _illnessService.GetOneIllnessAsync(id, cancellationToken);
            return View(entity);
        }

        public async Task<IActionResult> EditRoom(int id, CancellationToken cancellationToken)
        {
            var entity = await _roomService.GetOneRoomAsync(id, cancellationToken);
            return View(entity);
        }

        public async Task<IActionResult> DeletePatient(int id, CancellationToken cancellationToken)
        {
            await _patientService.RemovePateintAsync(id, cancellationToken);
            return RedirectToAction("PatientsMain");
        }

        public async Task<IActionResult> DeleteDoctor(int id, CancellationToken cancellationToken)
        {
            await _doctorService.RemoveDoctorAsync(id, cancellationToken);
            return RedirectToAction("DoctorsMain");
        }

        public async Task<IActionResult> DeleteProcedure(int id, CancellationToken cancellationToken)
        {
            await _procedureService.RemoveProcedureAsync(id, cancellationToken);
            return RedirectToAction("ProceduresMain");
        }

        public async Task<IActionResult> DeleteIllness(int id, CancellationToken cancellationToken)
        {
            await _illnessService.RemoveIllnessAsync(id, cancellationToken);
            return RedirectToAction("IllnessesMain");
        }

        public async Task<IActionResult> DeleteRoom(int id, CancellationToken cancellationToken)
        {
            await _roomService.RemoveRoomAsync(id, cancellationToken);
            return RedirectToAction("RoomsMain");
        }

        public async Task<IActionResult> DeleteReciept(int id, CancellationToken cancellationToken)
        {
            await _recieptService.DeleteRecieptAsync(id, cancellationToken);
            return RedirectToAction("RecieptsMain");
        }

        public async Task<IActionResult> SubmitAddDoctor(DoctorDto doctor, CancellationToken cancellationToken)
        {
            await _doctorService.AddDoctorAsync(doctor, cancellationToken);
            return RedirectToAction("DoctorsMain");
        }

        public async Task<IActionResult> SubmitAddPatient(PatientDto patient, CancellationToken cancellationToken)
        {
            await _patientService.AddPateintAsync(patient, cancellationToken);
            return RedirectToAction("PatientsMain");
        }

        public async Task<IActionResult> SubmitAddProcedure(ProcedureDto procedure, CancellationToken cancellationToken)
        {
            await _procedureService.AddProcedureAsync(procedure, cancellationToken);
            return RedirectToAction("ProceduresMain");
        }

        public async Task<IActionResult> SubmitAddIllness(IllnessDto illnessDto, CancellationToken cancellationToken)
        {
            await _illnessService.AddIllnessAsync(illnessDto, cancellationToken);
            return RedirectToAction("IllnessesMain");
        }

        public async Task<IActionResult> SubmitAddRoom(RoomDto roomDto, CancellationToken cancellationToken)
        {
            await _roomService.AddRoomAsync(roomDto, cancellationToken);
            return RedirectToAction("RoomsMain");
        }

        public async Task<IActionResult> SubmitAddVoucher(AddVoucherModel model, CancellationToken cancellationToken)
        {
            var vocherRoom = new VoucherRoomDto
            {
                DayCount = model.DayCount,
                RoomId= model.RoomId,
            };

            var voucherDto = new VoucherDto
            {
                CreationDate = model.CreationDate,
                ExpirationDate = model.ExpirationDate,
                PatientId = model.PatientId,
                IllnessId = model.IllnessId,
                VoucherRooms = new List<VoucherRoomDto> { vocherRoom},
            };

            await _voucherService.AddVoucherAsync(voucherDto, cancellationToken);

            return RedirectToAction("VouchersMain");
        }

        public async Task<IActionResult> SubmitEditDoctor(DoctorDto doctor, CancellationToken cancellationToken)
        {
            await _doctorService.UpdateDoctorAsync(doctor, cancellationToken);
            return RedirectToAction("DoctorsMain");
        }

        public async Task<IActionResult> SubmitEditPatient(PatientDto patient, CancellationToken cancellationToken)
        {
            await _patientService.UpdatePatientAsync(patient, cancellationToken);
            return RedirectToAction("PatientsMain");
        }

        public async Task<IActionResult> SubmitEditProcedure(ProcedureDto procedure, CancellationToken cancellationToken)
        {
            await _procedureService.UpdateProcedureAsync(procedure, cancellationToken);
            return RedirectToAction("ProceduresMain");
        }

        public async Task<IActionResult> SubmitEditIllness(IllnessDto illnessDto, CancellationToken cancellationToken)
        {
            await _illnessService.UpdateIllnessAsync(illnessDto, cancellationToken);
            return RedirectToAction("IllnessesMain");
        }

        public async Task<IActionResult> SubmitEditRoom(RoomDto roomDto, CancellationToken cancellationToken)
        {
            await _roomService.UpdateRoomAsync(roomDto, cancellationToken);
            return RedirectToAction("RoomsMain");
        }

        public async Task<IActionResult> SubmitGeneration(int id, CancellationToken cancellationToken)
        {
            var pdf = await _voucherService.GenerateDirectionPdf(id, cancellationToken);
            var file = new FileContentResult(pdf, "application/pdf");
            return file;
        }
    }
}