using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UltraSoundWeb.Models;
using UltraSoundWeb.Repositories.Context;
using UltraSoundWeb.Repositories.Doctor;

namespace UltraSoundWeb.Controllers
{
    [Authorize]
    public class DoctorsController : Controller
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public DoctorsController(IDoctorRepository doctorRepository, IMapper mapper, AppDbContext context)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ActionResult> Index()
        {
            var doctors = await _doctorRepository.GetDoctors();
            return View(doctors.ToList());
        }

        public ActionResult Create()
        {
            var specializeds = _context.Specializeds.ToList();
            ViewData["specializeds"] = specializeds;
            return View(new DoctorVM());
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromForm] DoctorVM vm)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Message"] = "Dữ liệu không hợp lệ";
                return View(vm);
            }
            try
            {
                await _doctorRepository.AddDoctor(vm);

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
            var doctor = await _doctorRepository.GetDoctor(id);
            ViewData["doctor"] = doctor;
            var specializeds = _context.Specializeds.ToList();
            ViewData["specializeds"] = specializeds;
            var res = _mapper.Map<DoctorVM>(doctor);
            res.UserName = doctor.User.Username;
            res.Password = doctor.User.Password;
            return View(res);
        }

        [HttpPost]
        public async Task<ActionResult> Edit([FromForm] DoctorVM vm)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Message"] = "Dữ liệu không hợp lệ";
                return View(vm);
            }
            try
            {
                await _doctorRepository.UpdateDoctor(vm);
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
                await _doctorRepository.DeleteDoctor(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Redirect("/doctors?error=true");
            }

        }
    }
}
