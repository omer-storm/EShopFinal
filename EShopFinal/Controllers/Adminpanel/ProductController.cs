using EShopFinal.Models;
using EShopMVCDotNetCore.Data;
using Microsoft.AspNetCore.Mvc;

namespace EShopFinal.Controllers.Adminpanel
{
    public class ProductController : Controller
    {
        ApplicationDBContext db;

        public ProductController(ApplicationDBContext _db)
        {
            db = _db;
        
        }

        [Route("Adminpanel/Product/")]
        public IActionResult Index()
        {
            var Products = db.Product.Select(x => x)
                .OrderBy(x => x.DisplayOrder)
                .ToList();
            return View(Products);
        }

        [HttpGet]
        [Route("Adminpanel/Product/Create/")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Adminpanel/Product/Create/")]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                if (db.Product.Any(x => x.Name == product.Name))
                {
                    return View(product);
                }
                db.Product.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpGet]
        public ActionResult Edit(int? Id)
        {
            if (Id == null)
                return NotFound();

            var product = db.Product.Where(p => p.Id == Id).FirstOrDefault();

            if (product == null)
                return NotFound();

            return View(product);
        }



        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Product.Update(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);


        }

        [HttpGet]
        [Route("Adminpanel/Product/Delete/")]
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var product = db.Product.FirstOrDefault(x => x.Id == Id);
            if (product == null)
            {
                return NotFound();
            }
            db.Product.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
