using AutoMapper;

#pragma warning disable CS8602 // Dereference of a possibly null reference.
namespace VLS.Infrastructure.Mappers
{
    public class MAPCity : Profile
    {
        public MAPCity() 
        {
            CreateMap<City, DTOCity>();
            CreateMap<DTOCity, City>();

            CreateMap<City, VMCity>()
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src == null ? string.Empty : src.Country.Name ));
        }
    }
}
