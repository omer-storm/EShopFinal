using Microsoft.AspNetCore.Mvc;

namespace EShopFinal.Controllers.Adminpanel
{
    public class OrderController : Controller
    {
        [Route("Adminpanel/Order/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
