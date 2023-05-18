using AutoMapper;

#pragma warning disable CS8604 // Possible null reference argument.
namespace VLS.Infrastructure.Mappers
{
    public class MAPCountry : Profile
    {
        public MAPCountry() 
        {
            CreateMap<Country, DTOCountry>();
            CreateMap<DTOCountry, Country>();

            CreateMap<Country, VMCountry>()
                .ForMember(dest => dest.Cities, opt => opt.MapFrom(src => src == null ? new List<string>() : src.Cities.Select(x => x.Name).ToList()));
        }
    }
}
