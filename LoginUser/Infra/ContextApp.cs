using LoginUser.Model;
using Microsoft.EntityFrameworkCore;

namespace LoginUser.Infra
{
    public class ContextApp : DbContext
    {
        public ContextApp(DbContextOptions<ContextApp> options) : base(options)
        {
        }

        public DbSet<UserModel> User { get; set; }
    }
}
