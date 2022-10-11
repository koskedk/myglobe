using Microsoft.EntityFrameworkCore;
using MyGlobe.Domain;

namespace MyGlobe.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}