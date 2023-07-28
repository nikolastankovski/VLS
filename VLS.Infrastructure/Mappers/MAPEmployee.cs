using AutoMapper;

namespace VLS.Infrastructure.Mappers
{
    public class MAPEmployee : Profile
    {
        public MAPEmployee()
        {
            CreateMap<Employee, DTOEmployee>();
            CreateMap<DTOEmployee, Employee>();

            CreateMap<Employee, VMEmployee>()
                .ForMember(dest => dest.OrganizationalUnit, opt => opt.MapFrom(src => src.OrganizationalUnit == null ? string.Empty : src.OrganizationalUnit.Name));
        }
    }
}
