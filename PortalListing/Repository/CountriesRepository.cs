using Microsoft.EntityFrameworkCore;
using PortalListing.Contracts;
using PortalListing.Data;

namespace PortalListing.Repository
{
    public class CountriesRepository : GenericRepository<Country>, ICountriesRepository
    {
        private readonly PortalListingDbContext _context;

        public CountriesRepository(PortalListingDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<Country> GetDetails(int id)
        {
            return await _context.Countries.Include(q => q.Hotels).FirstOrDefaultAsync(q => q.Id == id);
        }
    }
}
