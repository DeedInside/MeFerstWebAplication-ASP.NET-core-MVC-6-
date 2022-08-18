using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MeFerstWebAplication.Models;

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
        public IActionResult BlogAdd()
        {
            return View();
        }
        public async Task<IActionResult> Blog()
        {
            ViewBag.BlogOut = await db.DbBlog.ToListAsync();
            return View();
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
        [HttpPost]
        public async Task<IActionResult> AddItems(BlogModel blogModel, IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                // путь к папке Files
                string path = "/image/" + uploadedFile.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                BlogModel blog = new BlogModel()
                {
                    Id = blogModel.Id,
                    Categori = blogModel.Categori,
                    Text_Content = blogModel.Text_Content,
                    Time = DateTime.Now.ToString("dd/MM/yyyy"),
                    Url_image = path
                };
                db.DbBlog.Add(blog);
                await db.SaveChangesAsync();
                return RedirectToAction("Blog");
            }
            // return NotFound();
            return View("Index");
        }
    }
}
