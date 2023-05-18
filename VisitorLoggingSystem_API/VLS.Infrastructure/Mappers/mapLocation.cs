using AutoMapper;

#pragma warning disable CS8602 // Dereference of a possibly null reference.
namespace VLS.Infrastructure.Mappers
{
    public class mapLocation : Profile
    {
        public mapLocation() 
        {
            CreateMap<Location, DTOLocation>();
            CreateMap<DTOLocation, Location>();

            CreateMap<Location, VMLocation>()
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src == null ? string.Empty : src.Country.Description))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src == null ? string.Empty : src.City.Description))
                .ForMember(dest => dest.Municipality, opt => opt.MapFrom(src => src == null ? string.Empty : src.Municipality.Description));
        }
    }
}
