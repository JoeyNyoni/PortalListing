using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PortalListing.Data.Configurations;

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

    // add this to setup dbcontext when projects are segregated

    //public class PortalListingDbContextFactory : IDesignTimeDbContextFactory<PortalListingDbContext>
    //{
    //    public PortalListingDbContext CreateDbContext(string[] args)
    //    {
    //        IConfiguration config = new ConfigurationBuilder()
    //            .SetBasePath(Directory.GetCurrentDirectory())
    //            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    //            .Build();

    //        var optionsBuilder = new DbContextOptionsBuilder<PortalListingDbContext>();
    //        var conn = config.GetConnectionString("PortalListingDbConnectionString");
    //        optionsBuilder.UseSqlServer(conn);
    //        return new PortalListingDbContext(optionsBuilder.Options);
    //    }
    //}
}
