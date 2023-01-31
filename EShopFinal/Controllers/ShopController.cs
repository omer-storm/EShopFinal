using Microsoft.AspNetCore.Mvc;

namespace EShopFinal.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Cart()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Purchase()
        {
            return View();
        }
    }
}
