using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PortalListing.API.Data.Configurations;

namespace PortalListing.Data
{
    public class PortalListingDbContext : IdentityDbContext<ApiUser>
    {
        public PortalListingDbContext(DbContextOptions options) : base(options) 
        {
            
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new CountriesConfiguration());
            modelBuilder.ApplyConfiguration(new HotelsConfiguration());
        }
    }
}
