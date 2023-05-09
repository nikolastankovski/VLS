namespace VLS.Domain.Entities
{
    public class Course : BaseEntity
    {
        public Course()
        {
            CourseVersions = new HashSet<CourseVersion>();
            VisitorCourses = new HashSet<VisitorCourse>();
        }
        public int Course_ID { get; set; }
        public string Name { get; set; } = null!;
        public string ShortName { get; set; } = null!;
        public bool IsMandatory { get; set; } = false;

        public virtual ICollection<CourseVersion> CourseVersions { get; set; }
        public virtual ICollection<VisitorCourse> VisitorCourses { get; set; }

    }
}
