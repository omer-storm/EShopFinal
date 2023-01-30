using EShopFinal.Models;
using EShopMVCDotNetCore.Data;
using Microsoft.AspNetCore.Mvc;

namespace EShopFinal.Controllers.Adminpanel
{
    public class BannerController : Controller
    {
        ApplicationDBContext db;

        public BannerController(ApplicationDBContext _db)
        {
            db = _db;
        }

        [Route("Adminpanel/Banner/")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Adminpanel/Banner/Create/")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Adminpanel/Banner/Create/")]
        public IActionResult Create(Banner banner)
        {
            if (ModelState.IsValid)
            {
                if (db.Banner.Any(x => x.Name == banner.Name))
                {
                    return View(banner);
                }
                db.Banner.Add(banner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(banner);
        }
    }
}
