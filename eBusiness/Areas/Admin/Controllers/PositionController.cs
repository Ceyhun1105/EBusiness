using eBusiness.DbContextFiles;
using eBusiness.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eBusiness.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class PositionController : Controller
    {
        private readonly AppDbContext _context;

        public PositionController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Position> positions = _context.Positions.ToList();
            return View(positions);
        }
        public IActionResult Create()
        {
            return View();
        }
        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public IActionResult Create(Position position)
        {
            if (!ModelState.IsValid) return View(position);

            _context.Positions.Add(position);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {
            Position position = _context.Positions.FirstOrDefault(x => x.Id == id);
            if (position is null) return NotFound();

            return View(position);
        }
        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public IActionResult Update(Position position)
        {
            Position existposition = _context.Positions.FirstOrDefault(x => x.Id == position.Id);
            if (!ModelState.IsValid) return View(position);

            existposition.Name = position.Name;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Position position = _context.Positions.FirstOrDefault(x => x.Id == id);
            if (position is null) return NotFound();

            _context.Positions.Remove(position);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
