using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Spire.Pdf.Graphics;
using Spire.Pdf.HtmlConverter.Qt;
using System.Drawing;
using UltraSoundWeb.Models;
using UltraSoundWeb.Repositories.Context;
using UltraSoundWeb.Repositories.UltraSoundResult;

namespace UltraSoundWeb.Controllers
{
    [Authorize]
    public class UltraSoundResultsController : Controller
    {
        private readonly IUltraSoundResultRepository _ultraSoundResultRepository;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _appEnvironment;

        public UltraSoundResultsController(IUltraSoundResultRepository ultraSoundResultRepository, IMapper mapper, AppDbContext context, IWebHostEnvironment appEnvironment)
        {
            _ultraSoundResultRepository = ultraSoundResultRepository;
            _mapper = mapper;
            _context = context;
            _appEnvironment = appEnvironment;
        }

        public async Task<ActionResult> Index()
        {
            var ultraSoundResults = await _ultraSoundResultRepository.GetUltraSoundResults();
            foreach (var item in ultraSoundResults)
            {
                var d = await _context.Doctors.FindAsync(item.DoctorUltraSoundId);
                ViewData["UltraSound" + d.Id.ToString()] = d.Name;
            }
            return View(ultraSoundResults.ToList());
        }

        public ActionResult Create()
        {
            var samples = _context.UltraSoundSamples.ToList();
            var patients = _context.Patients.ToList();
            var doctorUltrasounds = _context.Doctors.Where(x => x.Specialized.Id == 1).ToList();
            var doctorSpecifys = _context.Doctors.Where(x => x.Specialized.Id == 2).ToList();
            ViewData["samples"] = samples;
            ViewData["patients"] = patients;
            ViewData["doctorUltrasounds"] = doctorUltrasounds;
            ViewData["doctorSpecifys"] = doctorSpecifys;

            return View(new UltraSoundResultVM());
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromForm] UltraSoundResultVM vm)
        {
            if (!ModelState.IsValid)
            {
                var samples = _context.UltraSoundSamples.ToList();
                var patients = _context.Patients.ToList();
                var doctorUltrasounds = _context.Doctors.Where(x => x.Specialized.Id == 1).ToList();
                var doctorSpecifys = _context.Doctors.Where(x => x.Specialized.Id == 2).ToList();
                ViewData["samples"] = samples;
                ViewData["patients"] = patients;
                ViewData["doctorUltrasounds"] = doctorUltrasounds;
                ViewData["doctorSpecifys"] = doctorSpecifys;
                ViewData["Message"] = "Dữ liệu không hợp lệ";
                return View(vm);
            }
            try
            {
                await _ultraSoundResultRepository.AddUltraSoundResult(vm);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var samples = _context.UltraSoundSamples.ToList();
                var patients = _context.Patients.ToList();
                var doctorUltrasounds = _context.Doctors.Where(x => x.Specialized.Id == 1).ToList();
                var doctorSpecifys = _context.Doctors.Where(x => x.Specialized.Id == 2).ToList();
                ViewData["samples"] = samples;
                ViewData["patients"] = patients;
                ViewData["doctorUltrasounds"] = doctorUltrasounds;
                ViewData["doctorSpecifys"] = doctorSpecifys;
                ViewData["Message"] = "Không thể tạo mới";
                return View(vm);
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            var ultraSoundResult = await _ultraSoundResultRepository.GetUltraSoundResult(id);

            var samples = _context.UltraSoundSamples.ToList();
            var patients = _context.Patients.ToList();
            var doctorUltrasounds = _context.Doctors.Where(x => x.Specialized.Id == 1).ToList();
            var doctorSpecifys = _context.Doctors.Where(x => x.Specialized.Id == 2).ToList();

            ViewData["samples"] = samples;
            ViewData["patients"] = patients;
            ViewData["doctorUltrasounds"] = doctorUltrasounds;
            ViewData["doctorSpecifys"] = doctorSpecifys;
            ViewData["ultraSoundResult"] = ultraSoundResult;
            return View(_mapper.Map<UltraSoundResultVM>(ultraSoundResult));
        }

        [HttpPost]
        public async Task<ActionResult> Edit([FromForm] UltraSoundResultVM vm)
        {
            if (!ModelState.IsValid)
            {
                var samples = _context.UltraSoundSamples.ToList();
                var patients = _context.Patients.ToList();
                var doctorUltrasounds = _context.Doctors.Where(x => x.Specialized.Id == 1).ToList();
                var doctorSpecifys = _context.Doctors.Where(x => x.Specialized.Id == 2).ToList();

                ViewData["samples"] = samples;
                ViewData["patients"] = patients;
                ViewData["doctorUltrasounds"] = doctorUltrasounds;
                ViewData["doctorSpecifys"] = doctorSpecifys;
                ViewData["Message"] = "Dữ liệu không hợp lệ";
                return View(vm);
            }
            try
            {
                await _ultraSoundResultRepository.UpdateUltraSoundResult(vm);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var samples = _context.UltraSoundSamples.ToList();
                var patients = _context.Patients.ToList();
                var doctorUltrasounds = _context.Doctors.Where(x => x.Specialized.Id == 1).ToList();
                var doctorSpecifys = _context.Doctors.Where(x => x.Specialized.Id == 2).ToList();

                ViewData["samples"] = samples;
                ViewData["patients"] = patients;
                ViewData["doctorUltrasounds"] = doctorUltrasounds;
                ViewData["doctorSpecifys"] = doctorSpecifys;
                ViewData["Message"] = "Không thể tạo mới";
                return View(vm);
            }
        }

        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                await _ultraSoundResultRepository.DeleteUltraSoundResult(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Redirect("/ultraSoundResults?error=true");
            }

        }

        [AllowAnonymous]
        public async Task<ActionResult> Detail(long id)
        {
            var ultraSoundResult = await _ultraSoundResultRepository.GetUltraSoundResult(id);
            var doctorUltrasounds = _context.Doctors.Where(x => x.Id == ultraSoundResult.DoctorUltraSoundId).FirstOrDefault();
            var info = _context.Infos.FirstOrDefault();

            ViewData["info"] = info;
            ViewData["ultraSoundResult"] = ultraSoundResult;
            var res = _mapper.Map<UltraSoundResultVM>(ultraSoundResult);
            res.DoctorUltraSound = _mapper.Map<DoctorVM>(doctorUltrasounds);

            return View(res);
        }

        public ActionResult Export(long id)
        {
            try
            {
                var request = HttpContext.Request;
                string url = $"{request.Scheme}://{request.Host}/ultrasoundresults/detail/{id}";
                string fileName = _appEnvironment.WebRootPath + $"\\pdf\\KetQuaSieuAm_ID_{id}_{Guid.NewGuid()}.pdf";
                string pluginPath = _appEnvironment.WebRootPath + "\\plugins-32";
                if (Environment.Is64BitOperatingSystem)
                {
                    pluginPath = _appEnvironment.WebRootPath + "\\plugins-64";
                }

                HtmlConverter.PluginPath = pluginPath;
                HtmlConverter.Convert(url, fileName, true, 1000000, new SizeF(595f, 842f), new PdfMargins(0, 7, 0, 7));

                byte[] filedata = System.IO.File.ReadAllBytes(fileName);

                var cd = new System.Net.Mime.ContentDisposition
                {
                    FileName = fileName,
                    Inline = true,
                };

                Task.Run(() => System.IO.File.Delete(fileName));

                Response.Headers.Add("Content-Disposition", cd.ToString());

                return File(filedata, "application/force-download", Path.GetFileName(fileName));
            }
            catch
            {
                return Redirect("/ultraSoundResults?error=true");
            }

        }
    }
}
