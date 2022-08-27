using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeFerstWebAplication.Controllers
{
    public class PortfolioController : Controller
    {
        
        [Authorize(Roles = "Admin, User")]
        public IActionResult Portfolio()
        {
            return View();
        }
        public IActionResult Lograng()
        {
            return View();
        }
    }
}
