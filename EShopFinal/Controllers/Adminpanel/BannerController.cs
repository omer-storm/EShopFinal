using Microsoft.AspNetCore.Mvc;

namespace EShopFinal.Controllers.Adminpanel
{
    public class BannerController : Controller
    {
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
    }
}
