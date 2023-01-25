using eBusiness.DbContextFiles;
using eBusiness.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eBusiness.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SettingController : Controller
    {
        private readonly AppDbContext _context;

        public SettingController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Setting> settingList = _context.Settings.ToList();
            return View(settingList);
        }
        public IActionResult Update(int id)
        {
            Setting setting = _context.Settings.FirstOrDefault(x => x.Id == id);
            if(setting is null) return NotFound();

            return View(setting);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(Setting setting)
        {
            if (!ModelState.IsValid) return View(setting);
            var existsetting = _context.Settings.FirstOrDefault(x => x.Id == setting.Id);

            existsetting.Value=setting.Value;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
