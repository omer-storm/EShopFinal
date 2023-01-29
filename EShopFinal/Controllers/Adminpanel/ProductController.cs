using Microsoft.AspNetCore.Mvc;

namespace EShopFinal.Controllers.Adminpanel
{
    public class ProductController : Controller
    {
        [Route("Adminpanel/Product/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
