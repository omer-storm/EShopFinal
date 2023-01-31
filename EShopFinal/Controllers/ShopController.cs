﻿using EShopFinal.Models;
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
        public IActionResult Cart(int Id)
        {
            var product = db.Product.Where(p => p.Id == Id).FirstOrDefault();


            List<CartItem> list = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");

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

            ViewBag.CartItems = list;

            return View();
        }

        [HttpGet]
        public IActionResult Purchase()
        {
            return View();
        }
    }
}
