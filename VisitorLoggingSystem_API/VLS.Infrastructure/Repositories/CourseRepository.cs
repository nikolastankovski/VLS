using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace VLS.Infrastructure.Repositories
{
    public class CourseRepository : Repository<Course, VMCourse, DTOCourse>, ICourseRepository
    {
        public CourseRepository(VLSDbContext context, ILogger<Course> logger, IMapper mapper) : base(context, logger, mapper)
        {
        }
        internal override Expression<Func<Course, bool>> GetWhereClauseByPK(object id)
        {
            return x => x.CourseId == Convert.ToInt32(id);
        }
    }
}
