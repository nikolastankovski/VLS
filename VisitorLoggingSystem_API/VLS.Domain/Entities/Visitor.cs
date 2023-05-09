namespace VLS.Domain.Entities
{
    public class Visitor : BaseEntity
    {
        public Visitor() 
        {
            VisitorCourses = new HashSet<VisitorCourse>();
        }
        public long Visitor_ID { get; set; }
        public string FullName { get; set; } = null!;
        public int IDType_ID { get; set; }
        public string IDNumber { get; set; } = null!;
        public DateTime IDExpirationDate { get; set; }
        public string CountryCode { get; set; } = null!;
        public int? Company_ID { get; set; }

        public virtual Company? Company { get; set; }
        public virtual ICollection<VisitorCourse> VisitorCourses { get; set; }
    }
}
