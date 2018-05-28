using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace APIDemo.Models
{
    public class ApiDemoContext : IdentityDbContext
    {
        public DbSet<Car> Cars { get; set; }

        public ApiDemoContext(DbContextOptions<ApiDemoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Car>(entity =>
            {
                entity.Property(e => e.ModelName)
                    .IsRequired()
                    .HasMaxLength(10);
            });
        }
    }
}
