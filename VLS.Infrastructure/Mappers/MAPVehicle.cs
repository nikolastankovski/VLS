using AutoMapper;

namespace VLS.Infrastructure.Mappers
{
    public class MAPVehicle : Profile
    {
        public MAPVehicle()
        {
            CreateMap<Vehicle, DTOVehicle>();
            CreateMap<DTOVehicle, Vehicle>();

            CreateMap<Vehicle, VMVehicle>()
                .ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.Company == null ? string.Empty : src.Company.Name));
        }
    }
}
