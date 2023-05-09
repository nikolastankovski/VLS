using System.ComponentModel.DataAnnotations;

namespace VLS.Domain.Entities
{
    public class Visitor : BaseEntity
    {
        public Visitor() 
        {
            VisitorCourses = new HashSet<VisitorCourse>();
            TransactionVisitors = new HashSet<TransactionVisitor>();
        }
        public long Visitor_ID { get; set; }

        [MaxLength(255)]
        public string FullName { get; set; } = null!;
        public int IDType_ID { get; set; }

        [MaxLength(50)]
        public string IDNumber { get; set; } = null!;

        [DataType(DataType.Date)]
        public DateTime IDExpirationDate { get; set; }

        public int Country_ID { get; set; }
        public int? Company_ID { get; set; }

        public virtual Company? Company { get; set; }
        public virtual Reference? Country { get; set; }
        public virtual Reference? IDType { get; set; }
        public virtual ICollection<VisitorCourse> VisitorCourses { get; set; }
        public virtual ICollection<TransactionVisitor> TransactionVisitors { get; set; }
    }
}
