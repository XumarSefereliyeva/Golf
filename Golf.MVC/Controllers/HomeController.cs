using Golf.BL.Services;
using Golf.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Golf.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly GolfPrService _services;

        public HomeController(GolfPrService golfPrService)
        {
            _services = golfPrService;
        }
        public IActionResult Index()
        {
            List<GolfPr> golfs = _services.GetAllGolf();
            return View(golfs);
        }
    }
}
