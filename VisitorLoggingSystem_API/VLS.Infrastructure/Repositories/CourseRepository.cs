namespace VLS.Infrastructure.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(VLSDbContext context) : base(context)
        {
        }
    }
}
