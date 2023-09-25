using AutoMapper;
using PortalListing.Data;
using PortalListing.Models.Country;
using PortalListing.Models.Hotel;

namespace PortalListing.Configurations
{
    public class MapperConfig : Profile
    {
        // Map DTOs to model objects
        public MapperConfig()
        {
            CreateMap<Country, CreateCountryDTO>().ReverseMap();
            CreateMap<Country, GetCountryDTO>().ReverseMap();
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Country, UpdateCountryDTO>().ReverseMap();

            CreateMap<Hotel, HotelDto>().ReverseMap();
            CreateMap<Hotel, CreateHotelDto>().ReverseMap();
            CreateMap<Hotel, UpdateHotelDto>().ReverseMap();
        }
    }
}
