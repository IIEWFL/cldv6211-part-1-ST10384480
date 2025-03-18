using Microsoft.AspNetCore.Mvc;

namespace ST10384480_CLDV_Part1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "About EventEase Venue Booking System";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Contact Information";
            return View();
        }
    }
}