using Microsoft.Extensions.Logging;
using VLS.Domain.DbModels;
using VLS.Infrastructure.Data;
using VLS.Infrastructure.Interfaces.IRepositories;
using VLS.Infrastructure.Repositories.BaseRepositories;

namespace VLS.Infrastructure.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(VLSDbContext context, ILogger<Course> logger) : base(context, logger)
        {
        }
    }
}
