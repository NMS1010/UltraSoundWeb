using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UltraSoundWeb.Models;
using UltraSoundWeb.Repositories.Patient;

namespace UltraSoundWeb.Controllers
{
    [Authorize]
    public class PatientsController : Controller
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public PatientsController(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<ActionResult> Index()
        {
            var patients = await _patientRepository.GetPatients();
            return View(patients.ToList());
        }

        public ActionResult Create()
        {
            return View(new PatientVM());
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromForm] PatientVM vm)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Message"] = "Dữ liệu không hợp lệ";
                return View(vm);
            }
            try
            {
                await _patientRepository.AddPatient(vm);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewData["Message"] = "Không thể tạo mới";
                return View(vm);
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            var patient = await _patientRepository.GetPatient(id);
            ViewData["patient"] = patient;
            return View(_mapper.Map<PatientVM>(patient));
        }

        [HttpPost]
        public async Task<ActionResult> Edit([FromForm] PatientVM vm)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Message"] = "Dữ liệu không hợp lệ";
                return View(vm);
            }
            try
            {
                await _patientRepository.UpdatePatient(vm);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewData["Message"] = "Không thể tạo mới";
                return View(vm);
            }
        }

        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                await _patientRepository.DeletePatient(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Redirect("/patients?error=true");
            }

        }
    }
}
