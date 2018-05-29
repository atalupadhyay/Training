using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFDBFirstDemo.Models
{
    public partial class RacingContext : DbContext
    {
        public RacingContext()
        {
        }

        public RacingContext(DbContextOptions<RacingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Tournament> Tournament { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.HasOne(d => d.Tournament)
                    .WithMany(p => p.City)
                    .HasForeignKey(d => d.TournamentId);
            });

            modelBuilder.Entity<Tournament>(entity =>
            {
                entity.Property(e => e.Title).IsRequired();
            });
        }
    }
}
