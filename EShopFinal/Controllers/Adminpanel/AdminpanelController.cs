using Microsoft.AspNetCore.Mvc;

namespace EShopFinal.Controllers.Adminpanel
{
    public class AdminpanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
