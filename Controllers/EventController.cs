using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ST10384480_CLDV_Part1.Data;
using ST10384480_CLDV_Part1.Models;

namespace ST10384480_CLDV_Part1.Controllers
{
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Events.Include(e => e.Venue).ToListAsync());
        }

        public IActionResult Create()
        {
            ViewBag.Venues = _context.Venues.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Event eventItem)
        {
            if (ModelState.IsValid)
            {
                _context.Events.Add(eventItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Venues = _context.Venues.ToList();
            return View(eventItem);
        }
    }
}