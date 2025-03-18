using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ST10384480_CLDV_Part1.Data;
using ST10384480_CLDV_Part1.Models;

namespace ST10384480_CLDV_Part1.Controllers
{
    public class VenueController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VenueController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Venues.ToListAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            var venue = await _context.Venues.Include(v => v.Events).FirstOrDefaultAsync(v => v.Id == id);
            return venue == null ? NotFound() : View(venue);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Venue venue)
        {
            if (ModelState.IsValid)
            {
                _context.Venues.Add(venue);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(venue);
        }
    }
}