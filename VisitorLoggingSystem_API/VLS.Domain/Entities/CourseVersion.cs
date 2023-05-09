namespace VLS.Domain.Entities
{
    public class CourseVersion : BaseEntity
    {
        public int CourseVersion_ID { get; set; }
        public int Course_ID { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public int ValidityPeriodInMonths { get; set; }

        public virtual Course? Course { get; set; }
    }
}
