using MeFerstWebAplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeFerstWebAplication.Controllers
{
    public class BlogController : Controller
    {
        ApplicationContext db;
        public BlogController(ApplicationContext context)
        {
            this.db = context;
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
