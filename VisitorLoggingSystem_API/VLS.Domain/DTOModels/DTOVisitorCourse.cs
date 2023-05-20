using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VLS.Domain.DTOModels
{
    public class DTOVisitorCourse
    {
        public int VisitorCourseId { get; set; }
        public long VisitorId { get; set; }
        public int CourseId { get; set; }
        public int LocationId { get; set; }

        [Column(TypeName = "date"), DataType(DataType.Date)]
        public DateOnly? DateCourseTaken { get; set; }
        public int SignatureFileId { get; set; }
    }
}
