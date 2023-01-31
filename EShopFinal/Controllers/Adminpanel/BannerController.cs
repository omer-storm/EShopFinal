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
            var Banners = db.Banner.Select(x => x)
                .OrderBy(x => x.DisplayOrder)
                .ToList();
            return View(Banners);
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

        [HttpGet]
        public ActionResult Edit(int? Id)
        {
            if (Id == null)
                return NotFound();

            var banner = db.Banner.Where(p => p.Id == Id).FirstOrDefault();

            if (banner == null)
                return NotFound();
            
            return View(banner);
        }



        [HttpPost]
        public IActionResult Edit(Banner banner)
        {
            if (ModelState.IsValid)
            {
                db.Banner.Update(banner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(banner);


        }



        [HttpGet]
        [Route("Adminpanel/Banner/Delete/")]
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var banner = db.Banner.FirstOrDefault(x => x.Id == Id);
            if (banner == null)
            {
                return NotFound();
            }
            db.Banner.Remove(banner);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
