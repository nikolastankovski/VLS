using AutoMapper;

namespace VLS.Infrastructure.Mappers
{
    public class MAPCity : Profile
    {
        public MAPCity() 
        {
            CreateMap<City, DTOCity>();
            CreateMap<DTOCity, City>();

            CreateMap<City, VMCity>()
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country == null ? string.Empty : src.Country.Name ));
        }
    }
}
