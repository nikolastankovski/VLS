using System.ComponentModel.DataAnnotations;
using VLS.Domain.Entities;

namespace VLS.Domain.Entities
{
    public class Location : BaseEntity
    {
        public Location() 
        {
            VisitorCourses = new HashSet<VisitorCourse>();
            TransactionVisitors = new HashSet<TransactionVisitor>();
            TransactionVehicles = new HashSet<TransactionVehicle>();
        }
        public int Location_ID { get; set; }

        [MaxLength(255)]
        public string Name { get; set; } = null!;
        public int Country_ID { get; set; }
        public int? City_ID { get; set; }
        public int? Municipality_ID { get; set; }

        [MaxLength(255)]
        public string? Address { get; set; }

        public virtual ICollection<VisitorCourse>? VisitorCourses { get; set; }
        public virtual ICollection<TransactionVisitor>? TransactionVisitors { get; set; }
        public virtual ICollection<TransactionVehicle>? TransactionVehicles { get; set; }
        public virtual Reference? Country { get; set; }
        public virtual Reference? City { get; set; }
        public virtual Reference? Municipality { get; set; }
    }
}
