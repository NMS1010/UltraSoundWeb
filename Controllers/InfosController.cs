using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UltraSoundWeb.Models;
using UltraSoundWeb.Repositories.Context;
using UltraSoundWeb.Services;

namespace UltraSoundWeb.Controllers
{
    [Authorize]
    public class InfosController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IUploadService _uploadService;
        private readonly IMapper _mapper;

        public InfosController(AppDbContext context, IMapper mapper, IUploadService uploadService)
        {
            _context = context;
            _mapper = mapper;
            _uploadService = uploadService;
        }

        public IActionResult Index()
        {
            var info = _context.Infos.FirstOrDefault();
            if (info == null)
            {
                info = new Entities.Info();
                _context.Infos.Add(info);
                _context.SaveChanges();
            }
            return View(_mapper.Map<InfoVM>(info));
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromForm] InfoVM vm)
        {
            var info = _context.Infos.FirstOrDefault(x => x.Id == vm.Id);
            _mapper.Map(vm, info);
            var p = "";
            if (vm.Image != null)
            {
                p = info.LogoImage;
                info.LogoImage = await _uploadService.SaveFile(vm.Image);
            }
            _context.Infos.Update(info);
            _context.SaveChanges();
            if (!string.IsNullOrEmpty(p))
            {
                await _uploadService.DeleteFile(p);
            }
            return Redirect("/infos");
        }
    }
}
