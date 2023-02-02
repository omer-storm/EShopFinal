using System.Collections.Generic;
using System.Reflection;
using EShopFinal.Models;
using EShopMVCDotNetCore.Data;
using EShopMVCDotNetCore.Helper;
using Microsoft.AspNetCore.Mvc;

namespace EShopFinal.Controllers
{
    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public CartItem()
        {
            Product = new Product();
        }
    }

    public class ShopController : Controller
    {
        ApplicationDBContext db;

        public ShopController(ApplicationDBContext _db)
        {
            db = _db;

        }
        public IActionResult Index()
        {
            if (SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart") == null)
            {
                List<CartItem> list = new();
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", list);
            }

            var Products = db.Product.Select(x => x)
                .OrderBy(x => x.DisplayOrder)
                .ToList();
            return View(Products);
        }



        [HttpGet]
        public IActionResult Cart(int? Id)
        {
            if (SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart") == null)
            {
                return RedirectToAction("Index");
            }

                List<CartItem> list = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");

            if (Id != null)
            {
                var product = db.Product.Where(p => p.Id == Id).FirstOrDefault();

                if (list != null)
                {

                    if (!list.Any(i => i.Product.Id == Id))
                        list.Add(new CartItem { Product = product, Quantity = 1 });
                    else
                    {
                        var ExistingItem = list.Where(i => i.Product.Id == Id).First();
                        ExistingItem.Quantity++;
                    }

                }
                else
                    list.Add(new CartItem { Product = product, Quantity = 1 });


                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", list);
            }


            ViewBag.CartItems = list;

            return View();
        }

        [HttpGet]
        public IActionResult Purchase()
        {
            List<CartItem> list = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");

            if (list.Any())
            {

                return View();
            }
            else return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Purchase(Order order)
        {
            List<CartItem> list = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");

            if (ModelState.IsValid)
            {
                db.Order.Add(order);

                db.SaveChanges();

                foreach (var item in list)
                {
                    db.CartItem.Add(new Models.CartItem { ProductId = item.Product.Id, OrderId = order.Id, Quantity = item.Quantity });
                }

                db.SaveChanges();


                HttpContext.Session.Remove("cart");


                return RedirectToAction("Index", "Home");
            }
            return View();

        }


        public IActionResult RemoveFromCart(int Id)
        {
            List<CartItem> list = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            int index = FindIndex(Id);
            list.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", list);
            return RedirectToAction("Cart");

        }

        private int FindIndex(int id)
        {
            List<CartItem> cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            int i = 0;
            foreach (var item in cart)
            {
                if (item.Product.Id == id)
                    return i;
                i = i + 1;
            }
            return -1;
        }
    }
}

