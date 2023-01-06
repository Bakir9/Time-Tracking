using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data.Config;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users {get; set;}
        public DbSet<Assignment> Assignments {get; set;}

        /*
        OnModelBuilder - metoda odgovorna za kreiranje migracije. Ona se override-a sa onim sto je unutar TaskConfiguration
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TaskConfiguration());
        }
    }
}