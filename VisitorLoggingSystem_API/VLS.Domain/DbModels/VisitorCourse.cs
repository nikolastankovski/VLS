using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VLS.Domain.DbModels
{
    public class VisitorCourse : BaseEntity
    {
        public int VisitorCourse_ID { get; set; }
        public long Visitor_ID { get; set; }
        public int Course_ID { get; set; }
        public int Location_ID { get; set; }

        [Column(TypeName = "date"), DataType(DataType.Date)]
        public DateTime? DateCourseTaken { get; set; }
        public int SignatureFile_ID { get; set; }

        public virtual Visitor? Visitor { get; set; }
        public virtual Course? Course { get; set; }
        public virtual Location? Location { get; set; }
        public virtual ApplicationFile? SignatureFile { get; set; }
    }
}
