using Microsoft.EntityFrameworkCore;
using MissilPolice.Models;

namespace MissilPolice.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Fir> Firs { get; set; }
        public DbSet<Accused> Accuseds { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fir>()
                .HasMany(f => f.AccusedList)
                .WithOne()
                .HasForeignKey(a => a.FIRID);
        }
    }
}
