using MeFerstWebAplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace MeFerstWebAplication.Controllers
{
    public class BlogController : Controller
    {
        ApplicationContext db;
        IWebHostEnvironment _appEnvironment;
        public BlogController(ApplicationContext context, IWebHostEnvironment appEnvironment)
        {
            this.db = context;
            this._appEnvironment = appEnvironment;
        }
        public async Task<IActionResult> Blog()
        {
            ViewBag.BlogOut = await db.DbBlog.ToListAsync();
            return View();
        }
        //public IActionResult Contact()
        //{
        //    return View();
        //}

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
            string path;
            if (uploadedFile == null)
            {
                path = "/image/BlackSqaut.png";
            }
            else
            {
                // путь к папке Files
                path = "/image/" + uploadedFile.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
            }
            if (blogModel.Text_Content != null && blogModel.Categori != null)
            {
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
            else
                return NotFound();

        }
        [HttpPost]
        public async Task<ActionResult> FundCategoti(FundModel fundModel)
        {
            if(fundModel != null)
            {
                var fund = await db.DbBlog.Where(p => p.Categori == fundModel.ChectCategori).ToListAsync();
                ViewBag.BlogOut = fund;
            }
            if (fundModel.ChectCategori == "Всё")
            {
                ViewBag.BlogOut = await db.DbBlog.ToListAsync();
            }
            return View("Blog");
        }
    }
}

