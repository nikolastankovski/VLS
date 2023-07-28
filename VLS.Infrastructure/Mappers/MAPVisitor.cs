using AutoMapper;

#pragma warning disable CS8602 // Dereference of a possibly null reference.

namespace VLS.Infrastructure.Mappers
{
    public class MAPVisitor : Profile
    {
        public MAPVisitor()
        {
            CreateMap<Visitor, DTOVisitor>();
            CreateMap<DTOVisitor, Visitor>();

            CreateMap<Visitor, VMVisitor>()
                .ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.Company == null ? string.Empty : src.Company.Name))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country == null ? string.Empty : src.Country.Description))
                .ForMember(dest => dest.IDType, opt => opt.MapFrom(src => src.IDType == null ? string.Empty : src.IDType.Description))
                .ForMember(dest => dest.VisitorCourses, opt => opt.MapFrom(src => src.VisitorCourses == null ? new List<string>() : src.VisitorCourses.Select(x => x.Course.Name).ToList()));
        }
    }
}
