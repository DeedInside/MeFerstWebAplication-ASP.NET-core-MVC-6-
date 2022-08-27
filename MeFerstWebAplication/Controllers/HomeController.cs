using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MeFerstWebAplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace MeFerstWebAplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        [Authorize(Roles = "Admin, User")]
        public IActionResult Skils()
        {
            return View();
        }
        [Authorize(Roles = "Admin, User")]
        public IActionResult Edication()
        {
            return View();
        }
        [Authorize(Roles = "Admin, User")]
        public IActionResult Experiece()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Contact()
        {
            return View();
        }
        
        //[HttpPost]
        //public async Task<IActionResult> Logout()
        //{
        //    await _signInManager.SignOutAsync();
        //    return RedirectToAction("Index", "Home");
        //}
    }
}
