using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VLS.Domain.DTOModels
{
    public class DTOVisitorCourse
    {
        public int VisitorCourse_ID { get; set; }
        public long Visitor_ID { get; set; }
        public int Course_ID { get; set; }
        public int Location_ID { get; set; }

        [Column(TypeName = "date"), DataType(DataType.Date)]
        public DateOnly? DateCourseTaken { get; set; }
        public int SignatureFile_ID { get; set; }
    }
}
