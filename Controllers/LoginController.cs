using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UltraSoundWeb.Common.Enums;
using UltraSoundWeb.Entities;
using UltraSoundWeb.Models;
using UltraSoundWeb.Repositories.User;

namespace UltraSoundWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;

        public LoginController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        private async Task AssignCookies(User user)
        {
            var claims = new List<Claim>()
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Name, user.Username),
                new(ClaimTypes.Role, user.Role.ToString()),
            };

            var identity = new ClaimsIdentity(claims, "UserAuth");

            var userPrincipal = new ClaimsPrincipal(identity);
            var authProperties = new AuthenticationProperties()
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(10),
            };
            await HttpContext.SignInAsync(
                "UserAuth",
                userPrincipal,
                authProperties
            );
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginVM vm)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Message"] = "Tài khoản hoặc mật khẩu không chính xác";
                return View(vm);
            }
            var user = await _userRepository.Login(vm);
            if (user == null)
            {
                ViewData["Message"] = "Tài khoản hoặc mật khẩu không chính xác";
                return View(vm);
            }

            HttpContext.Session.SetString("UserId", user.Id.ToString());
            HttpContext.Session.SetString("DoctorId", user.Doctor.Id.ToString());
            HttpContext.Session.SetString("Name", user.Doctor.Name);
            HttpContext.Session.SetString("Role", user.Role.ToString());
            await AssignCookies(user);
            var url = "/";
            if (user.Role == ROLE.DOCTOR)
            {
                url = "/ultrasoundresults";
            }
            return Redirect(url);
        }
    }
}