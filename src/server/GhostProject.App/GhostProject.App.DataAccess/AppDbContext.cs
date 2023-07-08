using System.Reflection;
using GhostProject.App.Core.Business.Companies.Entities;
using GhostProject.App.Core.Business.Rates.Entities;
using GhostProject.App.Core.Business.Recruiters.Entities;
using GhostProject.App.Core.Business.Users.Entities;
using Microsoft.EntityFrameworkCore;

namespace GhostProject.App.DataAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } 
        public DbSet<Company> Companies { get; set; }

        public DbSet<Recruiter> Recruiters { get; set; }
        
        public DbSet<Rate> Rates { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasPostgresExtension("uuid-ossp");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
