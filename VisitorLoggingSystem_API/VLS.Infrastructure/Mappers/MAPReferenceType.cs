using AutoMapper;

namespace VLS.Infrastructure.Mappers
{
    public class MAPReferenceType : Profile
    {
        public MAPReferenceType()
        {
            CreateMap<ReferenceType, DTOReferenceType>();
            CreateMap<DTOReferenceType, ReferenceType>();

            CreateMap<ReferenceType, VMReferenceType>()
                .ForMember(dest => dest.References, opt => opt.MapFrom(src => src.References == null ? new List<Reference>() : src.References.ToList()));
        }
    }
}
