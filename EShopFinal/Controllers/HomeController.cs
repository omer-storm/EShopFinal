using System.Diagnostics;
using EShopFinal.Models;
using EShopMVCDotNetCore.Data;
using Microsoft.AspNetCore.Mvc;

namespace EShopFinal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ApplicationDBContext db;

        public HomeController(ApplicationDBContext _db, ILogger<HomeController> logger)
        {
            _logger = logger;
            db = _db;
        }

        public IActionResult Index()
        {
            var Banners = db.Banner.Select(x => x)
                .OrderBy(x => x.DisplayOrder)
                .ToList();
            return View(Banners);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}