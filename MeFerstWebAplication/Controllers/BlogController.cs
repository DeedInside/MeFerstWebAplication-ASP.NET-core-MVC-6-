﻿using MeFerstWebAplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.IO;

namespace MeFerstWebAplication.Controllers
{
    public class BlogController : Controller
    {
        ApplicationContext db;
        IWebHostEnvironment _appEnvironment;
        private readonly ILogger _logger;
        public BlogController(ApplicationContext context, IWebHostEnvironment appEnvironment, ILogger<HomeController> logger)
        {
            this.db = context;
            this._appEnvironment = appEnvironment;
            this._logger = logger;
        }
        
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> Blog()
        {
            ViewBag.BlogOut = await db.DbBlog.ToListAsync();
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

            if (blogModel.Time == null)
            {
                blogModel.Time = DateTime.Now.ToString("dd/MM/yyyy");
            }

            if (blogModel.Text_Content != null && blogModel.Categori != null)
            {
                BlogModel blog = new BlogModel()
                {
                    Id = blogModel.Id,
                    Categori = blogModel.Categori,
                    Text_Content = blogModel.Text_Content,
                    Time = blogModel.Time,
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

