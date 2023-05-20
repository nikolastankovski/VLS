using AutoMapper;

namespace VLS.Infrastructure.Mappers
{
    public class MAPReference : Profile
    {
        public MAPReference()
        {
            CreateMap<Reference, DTOReference>();
            CreateMap<DTOReference, Reference>();

            CreateMap<Reference, VMReference>()
                .ForMember(dest => dest.ReferenceType, opt => opt.MapFrom(src => src.ReferenceType == null ? string.Empty : src.ReferenceType.Description ));
        }
    }
}
