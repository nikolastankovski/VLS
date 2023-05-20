using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VLS.Domain.DbModels
{
    [Table(nameof(Course))]
    public class Course : BaseEntity
    {
        public Course()
        {
            CourseVersions = new HashSet<CourseVersion>();
            VisitorCourses = new HashSet<VisitorCourse>();
        }
        public int CourseId { get; set; }

        [MaxLength(255)]
        public string Name { get; set; } = null!;

        [MaxLength(50)]
        public string ShortName { get; set; } = null!;
        public bool IsMandatory { get; set; } = false;

        public virtual ICollection<CourseVersion> CourseVersions { get; set; }
        public virtual ICollection<VisitorCourse> VisitorCourses { get; set; }

    }
}
