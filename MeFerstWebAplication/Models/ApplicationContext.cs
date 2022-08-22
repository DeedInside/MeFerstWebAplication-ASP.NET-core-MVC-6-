using MeFerstWebAplication.Models.UserModel;
using Microsoft.EntityFrameworkCore;
namespace MeFerstWebAplication.Models
{
    public class ApplicationContext :DbContext
    {
        public DbSet<BlogModel> DbBlog { get; set; }
        public DbSet<User> DbUser { get; set; }
        public DbSet<Role> Roles { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
        {
            Database.EnsureCreated();
        }
    }
}
