using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ST10384480_CLDV_Part1.Data;
using ST10384480_CLDV_Part1.Models;

namespace ST10384480_CLDV_Part1.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Bookings.Include(b => b.Event).ThenInclude(e => e.Venue).ToListAsync());
        }

        public IActionResult Create()
        {
            ViewBag.Events = _context.Events.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Bookings.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Events = _context.Events.ToList();
            return View(booking);
        }
    }
}