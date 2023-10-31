using AutoMapper;
using PortalListing.Contracts;
using PortalListing.Data;

namespace PortalListing.Repository
{
    public class HotelRepository : GenericRepository<Hotel>, IHotelsRepository
    {
        public HotelRepository(PortalListingDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
