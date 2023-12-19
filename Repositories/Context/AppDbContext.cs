using Microsoft.EntityFrameworkCore;
using UltraSoundWeb.Repositories.Context.Configuration;

namespace UltraSoundWeb.Repositories.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public AppDbContext()
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
        }

        public DbSet<Entities.UltraSoundResult> UltraSoundResults { get; set; }
        public DbSet<Entities.User> Users { get; set; }
        public DbSet<Entities.Doctor> Doctors { get; set; }
        public DbSet<Entities.Patient> Patients { get; set; }
        public DbSet<Entities.Specialized> Specializeds { get; set; }
        public DbSet<Entities.UltraSoundSample> UltraSoundSamples { get; set; }
        public DbSet<Entities.ResultImage> ResultImages { get; set; }
        public DbSet<Entities.Info> Infos { get; set; }
    }
}
