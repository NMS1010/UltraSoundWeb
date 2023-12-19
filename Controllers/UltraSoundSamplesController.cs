using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UltraSoundWeb.Models;
using UltraSoundWeb.Repositories.UltraSoundSample;

namespace UltraSoundWeb.Controllers
{
    [Authorize]
    public class UltraSoundSamplesController : Controller
    {
        private readonly IUltraSoundSampleRepository _ultraSoundSampleRepository;
        private readonly IMapper _mapper;

        public UltraSoundSamplesController(IUltraSoundSampleRepository ultraSoundSampleRepository, IMapper mapper)
        {
            _ultraSoundSampleRepository = ultraSoundSampleRepository;
            _mapper = mapper;
        }

        public async Task<ActionResult> Index()
        {
            var ultraSoundSamples = await _ultraSoundSampleRepository.GetUltraSoundSamples();
            return View(ultraSoundSamples.ToList());
        }

        public ActionResult Create()
        {
            return View(new UltraSoundSampleVM());
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromForm] UltraSoundSampleVM vm)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Message"] = "Dữ liệu không hợp lệ";
                return View(vm);
            }
            try
            {
                await _ultraSoundSampleRepository.AddUltraSoundSample(vm);

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
            var ultraSoundSample = await _ultraSoundSampleRepository.GetUltraSoundSample(id);
            ViewData["ultraSoundSample"] = ultraSoundSample;
            return View(_mapper.Map<UltraSoundSampleVM>(ultraSoundSample));
        }

        [HttpPost]
        public async Task<ActionResult> Edit([FromForm] UltraSoundSampleVM vm)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Message"] = "Dữ liệu không hợp lệ";
                return View(vm);
            }
            try
            {
                await _ultraSoundSampleRepository.UpdateUltraSoundSample(vm);
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
                await _ultraSoundSampleRepository.DeleteUltraSoundSample(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Redirect("/ultraSoundSamples?error=true");
            }

        }
    }
}
