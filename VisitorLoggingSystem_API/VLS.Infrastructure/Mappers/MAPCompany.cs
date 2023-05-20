using AutoMapper;

namespace VLS.Infrastructure.Mappers
{
    public class MAPCompany : Profile
    {
        public MAPCompany()
        {
            CreateMap<Company, DTOCompany>();
            CreateMap<DTOCompany, Company>();

            CreateMap<Company, VMCompany>();
        }
    }
}
