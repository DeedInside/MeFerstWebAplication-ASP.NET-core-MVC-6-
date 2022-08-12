using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MeFerstWebAplication.Models;

namespace MeFerstWebAplication.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            this.db = context;

            //if(db.DbBlog.Any())
            //{

            //    BlogModel q_1 = new BlogModel { Categori = "Спорт", Text_Content = "11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 ", Time = "01.01.2022", Url_image = "/image/cat.png" };
            //    BlogModel q_2 = new BlogModel { Categori = "Отдых", Text_Content = "11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 ", Time = "01.01.2022", Url_image = "/image/cat.png" };
            //    BlogModel q_3 = new BlogModel { Categori = "Программирование", Text_Content = "11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 ", Time = "01.01.2022", Url_image = "/image/cat.png" };
            //    BlogModel q_4 = new BlogModel { Categori = "Спорт", Text_Content = "11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 11111 ", Time = "01.01.2022", Url_image = "/image/cat.png" };

            //    db.DbBlog.AddRange(q_1,q_2,q_3,q_4);
            //    db.SaveChanges();

            //}
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
        public async Task<IActionResult> Blog()
        {   
            return View(await db.DbBlog.ToListAsync());
        }
        public IActionResult Contact()
        {
            return View();
        }
       
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                BlogModel? Blog = await db.DbBlog.FirstOrDefaultAsync(p => p.Id == id);
                if (Blog != null)
                {
                    db.DbBlog.Remove(Blog);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Blog");
                }
            }
            return NotFound();
        }
    }
}
