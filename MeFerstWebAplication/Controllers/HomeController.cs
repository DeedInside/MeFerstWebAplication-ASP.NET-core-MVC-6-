using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MeFerstWebAplication.Models;
using Microsoft.AspNetCore.Authorization;

namespace MeFerstWebAplication.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext db;
        IWebHostEnvironment _appEnvironment;
        public HomeController(ApplicationContext context, IWebHostEnvironment appEnvironment)
        {
            this.db = context;
            this._appEnvironment = appEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Skils()
        {
            return View();
        }
        public IActionResult Edication()
        {
            return View();
        }
        public IActionResult Portfolio()
        {
            return View();
        }
        public IActionResult Experiece()
        {
            return View();
        }
        //public IActionResult Blog()
        //{
        //    return RedirectPermanent("~/Home/Index");
        //    //return RedirectPermanent("~/Blog/Blog");
        //}
        
        public IActionResult Contact()
        {
            return View();
        }   
    }
}
