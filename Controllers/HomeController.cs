using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UltraSoundWeb.Repositories.Context;

namespace UltraSoundWeb.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Index", "Login");
            }
            ViewData["doctors"] = _context.Doctors.Count();
            ViewData["patients"] = _context.Patients.Count();
            ViewData["ultraSoundResults"] = _context.UltraSoundResults.Count();
            ViewData["ultraSoundSamples"] = _context.UltraSoundSamples.Count();

            ViewData["01-10"] = _context.Patients
                .Where(x => (DateTime.Now.Year - x.BirthYear) >= 1 && (DateTime.Now.Year - x.BirthYear) <= 10).Count();
            ViewData["11-20"] = _context.Patients
                .Where(x => (DateTime.Now.Year - x.BirthYear) >= 11 && (DateTime.Now.Year - x.BirthYear) <= 20).Count();
            ViewData["21-30"] = _context.Patients
                .Where(x => (DateTime.Now.Year - x.BirthYear) >= 21 && (DateTime.Now.Year - x.BirthYear) <= 30).Count();
            ViewData["31-40"] = _context.Patients.Where(x => (DateTime.Now.Year - x.BirthYear) >= 31 && (DateTime.Now.Year - x.BirthYear) <= 40)
                .Count();
            ViewData["41-50"] = _context.Patients.Where(x => (DateTime.Now.Year - x.BirthYear) >= 41 && (DateTime.Now.Year - x.BirthYear) <= 50)
                .Count();
            ViewData["51"] = _context.Patients.Where(x => (DateTime.Now.Year - x.BirthYear) >= 51)
                .Count();

            var totalPatients = _context.Patients.Count();
            ViewData["01-10%"] = Math.Round(1.0 * (int)ViewData["01-10"] / totalPatients * 100, 2);
            ViewData["11-20%"] = Math.Round(1.0 * (int)ViewData["11-20"] / totalPatients * 100, 2);
            ViewData["21-30%"] = Math.Round(1.0 * (int)ViewData["21-30"] / totalPatients * 100, 2);
            ViewData["31-40%"] = Math.Round(1.0 * (int)ViewData["31-40"] / totalPatients * 100, 2);
            ViewData["41-50%"] = Math.Round(1.0 * (int)ViewData["41-50"] / totalPatients * 100, 2);
            ViewData["51%"] = Math.Round(1.0 * (int)ViewData["51"] / totalPatients * 100, 2);

            var res = _context.UltraSoundSamples
                .Include(x => x.UltraSoundResults).ToList();

            ViewData["typeSounds"] = res;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Remove("UserId");
            HttpContext.Session.Remove("Name");
            await HttpContext.SignOutAsync("UserAuth");

            return Redirect("/");
        }

    }
}
