using Microsoft.EntityFrameworkCore;

namespace Jumia_MVC.Data
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions options):base(options)
        {

        }
    }
}
