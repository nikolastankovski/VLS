using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VLS.Domain.DbModels
{
    public class CourseVersion : BaseEntity
    {
        public int CourseVersion_ID { get; set; }
        public int Course_ID { get; set; }

        [Column(TypeName = "date"), DataType(DataType.Date)]
        public DateOnly ValidFrom { get; set; }

        [Column(TypeName = "date"), DataType(DataType.Date)]
        public DateOnly? ValidTo { get; set; }
        public int ValidityPeriodInMonths { get; set; }

        public virtual Course? Course { get; set; }
    }
}
