using AutoMapper;
using Microsoft.Extensions.Logging;

namespace VLS.Infrastructure.Repositories
{
    public class CourseRepository : Repository<Course, VMCourse, DTOCourse>, ICourseRepository
    {
        public CourseRepository(VLSDbContext context, ILogger<Course> logger, IMapper mapper) : base(context, logger, mapper)
        {
        }
    }
}
