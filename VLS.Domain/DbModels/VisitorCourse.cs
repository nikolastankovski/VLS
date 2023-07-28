using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VLS.Domain.DbModels
{
    [Table(nameof(VisitorCourse))]
    public class VisitorCourse : BaseEntity
    {
        public int VisitorCourseId { get; set; }
        public long VisitorId { get; set; }
        public int CourseId { get; set; }
        public int LocationId { get; set; }

        [Column(TypeName = "date"), DataType(DataType.Date)]
        public DateOnly? DateCourseTaken { get; set; }
        public int SignatureFileId { get; set; }

        public virtual Visitor? Visitor { get; set; }
        public virtual Course? Course { get; set; }
        public virtual Location? Location { get; set; }
        public virtual ApplicationFile? SignatureFile { get; set; }
    }
}
