using Microsoft.Extensions.Logging;

namespace VLS.Infrastructure.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(VLSDbContext context, ILogger<Course> logger) : base(context, logger)
        {
        }
    }
}
