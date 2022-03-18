using FWshop.Data.Entity;
using FWshop.Models.DTO;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FWshop.Data.Database
{
    public class DbContainer : IdentityDbContext
    {
        public DbContainer(DbContextOptions<DbContainer> options)
            : base(options)
        {

        }
        public DbSet<Department> Department { get; set; }
        public DbSet<Emploee> Emploee { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<District> District { get; set; }

    }
}
