using EShopFinal.Models;
using EShopMVCDotNetCore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EShopFinal.Controllers.Adminpanel
{
    public class Itemlist
    {
        public string Text { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }

    public class OrderController : Controller
    {

        ApplicationDBContext db;

        public OrderController(ApplicationDBContext _db)
        {
            db = _db;
        }

        [Route("Adminpanel/Order/")]
        public IActionResult Index()
        {
            List<Itemlist> list = new List<Itemlist>
            {
                new Itemlist { Text =  "recieved", Value = "recieved" },
                new Itemlist { Text =  "delivered", Value = "delivered" },
                new Itemlist { Text =  "cancelled", Value = "cancelled" }
            };

            ViewBag.Dropdown = list; 

            var Orders = db.Order.Select(x => x)
                .ToList();
            return View(Orders);
        }

        [HttpGet]
        public ActionResult Edit(int? Id)
        {
            if (Id == null)
                return NotFound();

            var order = db.Order.Where(p => p.Id == Id).FirstOrDefault();

            if (order == null)
                return NotFound();

            return View(order);
        }

        [HttpPost]
        public IActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                db.Order.Update(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);


        }

        [HttpGet]
        [Route("Adminpanel/Order/Detail/")]
        public ActionResult Detail(int? Id)
        {
            if (Id == null)
                return NotFound();

            var items = db.CartItem.Where(p => p.OrderId == Id).Include("Product").ToList();

    

            return View(items);
        }

    }
}
