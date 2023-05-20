using AutoMapper;

namespace VLS.Infrastructure.Mappers
{
    public class MAPOrganizationalUnit : Profile
    {
        public MAPOrganizationalUnit()
        {
            CreateMap<OrganizationalUnit, DTOOrganizationalUnit>();
            CreateMap<DTOOrganizationalUnit, OrganizationalUnit>();

            CreateMap<OrganizationalUnit, VMOrganizationalUnit>();
        }
    }
}
