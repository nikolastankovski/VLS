using AutoMapper;

namespace VLS.Infrastructure.Mappers
{
    public class MAPTransactionVehicle : Profile
    {
        public MAPTransactionVehicle()
        {
            CreateMap<TransactionVehicle, DTOTransactionVehicle>();
            CreateMap<DTOTransactionVehicle, TransactionVehicle>();

            CreateMap<TransactionVehicle, VMTransactionVehicle>()
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location == null ? string.Empty : src.Location.Name))
                .ForMember(dest => dest.Vehicle, opt => opt.MapFrom(src => src.Vehicle == null ? string.Empty : src.Vehicle.RegistrationNumber))
                .ForMember(dest => dest.EntryVisitor, opt => opt.MapFrom(src => src.EntryVisitor == null ? string.Empty : src.EntryVisitor.FullName))
                .ForMember(dest => dest.ExitVisitor, opt => opt.MapFrom(src => src.ExitVisitor == null ? string.Empty : src.ExitVisitor.FullName));

        }
    }
}
