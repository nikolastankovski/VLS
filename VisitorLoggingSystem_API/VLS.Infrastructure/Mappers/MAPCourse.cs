using AutoMapper;

namespace VLS.Infrastructure.Mappers
{
    public class MAPCourse : Profile
    {
        public MAPCourse()
        {
            CreateMap<Course, DTOCourse>();
            CreateMap<DTOCourse, Course>();

            CreateMap<Course, VMCourse>();
        }
    }
}
