using VLS.Domain.Entities;

namespace VLS.Domain.Entities
{
    public class Location : BaseEntity
    {
        public Location() 
        {
            VisitorCourses = new HashSet<VisitorCourse>();
        }
        public int Location_ID { get; set; }
        public string Name { get; set; } = null!;
        public int Country_ID { get; set; }
        public int? City_ID { get; set; }
        public int? Municipality_ID { get; set; }
        public string? Address { get; set; }

        public virtual ICollection<VisitorCourse> VisitorCourses { get; set; }
        public virtual Reference? Country { get; set; }
        public virtual Reference? City { get; set; }
        public virtual Reference? Municipality { get; set; }
    }
}
