using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VLS.Domain.DbModels
{
    [Table(nameof(CourseVersion))]
    public class CourseVersion : BaseEntity
    {
        public int CourseVersionId { get; set; }
        public int CourseId { get; set; }

        [Column(TypeName = "date"), DataType(DataType.Date)]
        public DateOnly ValidFrom { get; set; }

        [Column(TypeName = "date"), DataType(DataType.Date)]
        public DateOnly? ValidTo { get; set; }
        public int ValidityPeriodInMonths { get; set; }

        public virtual Course? Course { get; set; }
    }
}
