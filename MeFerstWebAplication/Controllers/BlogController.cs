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
                    Time = blogModel.Time,
                    Url_image = path
                };
                db.DbBlog.Add(blogModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Blog");
            }
            return NotFound();
        }
    }
}
