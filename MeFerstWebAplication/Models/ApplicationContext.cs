using Microsoft.EntityFrameworkCore;
namespace MeFerstWebAplication.Models
{
    public class ApplicationContext :DbContext
    {
        public DbSet<BlogModel> DbBlog { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
        {
            Database.EnsureCreated();
        }
    }
}
