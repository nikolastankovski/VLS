using AutoMapper;

namespace VLS.Infrastructure.Mappers
{
    public class MAPTransactionVisitor : Profile
    {
        public MAPTransactionVisitor()
        {
            CreateMap<TransactionVisitor, DTOTransactionVisitor>();
            CreateMap<DTOTransactionVisitor, TransactionVisitor>();

            CreateMap<TransactionVisitor, VMTransactionVisitor>()
                .ForMember(dest => dest.Visitor, opt => opt.MapFrom(src => src.Visitor == null ? string.Empty : src.Visitor.FullName))
                .ForMember(dest => dest.Visitee, opt => opt.MapFrom(src => src.Visitee == null ? string.Empty : src.Visitee.Name))
                .ForMember(dest => dest.OrganizationalUnit, opt => opt.MapFrom(src => src.OrganizationalUnit == null ? string.Empty : src.OrganizationalUnit.Name))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location == null ? string.Empty : src.Location.Name))
                .ForMember(dest => dest.Activity, opt => opt.MapFrom(src => src.Activity == null ? string.Empty : src.Activity.Description));

        }
    }
}
