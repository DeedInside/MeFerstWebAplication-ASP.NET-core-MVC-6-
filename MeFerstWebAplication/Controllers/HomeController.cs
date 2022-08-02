using Microsoft.AspNetCore.Mvc;

namespace MeFerstWebAplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
