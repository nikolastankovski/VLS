using System.ComponentModel.DataAnnotations;

namespace VLS.Domain.DbModels
{
    public class Course : BaseEntity
    {
        public Course()
        {
            CourseVersions = new HashSet<CourseVersion>();
            VisitorCourses = new HashSet<VisitorCourse>();
        }
        public int Course_ID { get; set; }

        [MaxLength(255)]
        public string Name { get; set; } = null!;

        [MaxLength(50)]
        public string ShortName { get; set; } = null!;
        public bool IsMandatory { get; set; } = false;

        public virtual ICollection<CourseVersion> CourseVersions { get; set; }
        public virtual ICollection<VisitorCourse> VisitorCourses { get; set; }

    }
}
