using Microsoft.AspNetCore.Mvc;

namespace Logistics.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
        }

        public IActionResult Index()
        {

            return RedirectToAction("Index", "Pizza", new { filePath = "Data/Data.json" });

        }
    }
}