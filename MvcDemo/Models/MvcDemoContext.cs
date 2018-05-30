using Microsoft.EntityFrameworkCore;

namespace MvcDemo.Models
{
    public class MvcDemoContext : DbContext
    {
    #region MvcDemoContext
        public MvcDemoContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
    #endregion
    }
}
