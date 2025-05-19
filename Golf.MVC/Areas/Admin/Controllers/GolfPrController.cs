using Golf.BL.Services;
using Golf.BL.ViewModels;
using Golf.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Golf.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GolfPrController : Controller
    {
        private readonly GolfPrService _services;

        public GolfPrController(GolfPrService services)
        {
            _services = services;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<GolfPr> golfs = _services.GetAllGolf();
            return View(golfs);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(GolfPrVM golfVM)
        {
            _services.Create(golfVM);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Info(int id)
        {
           GolfPr golfs= _services.GetGolfById(id);      
             return View(golfs);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var golfcard = _services.GetGolfbyIdLikeVM(id);
            if (golfcard == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(golfcard);
        }
        [HttpPost]
        public IActionResult Update(int id, GolfUpdateVM golfVM)
        {
            _services.Update(id,golfVM);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _services.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
