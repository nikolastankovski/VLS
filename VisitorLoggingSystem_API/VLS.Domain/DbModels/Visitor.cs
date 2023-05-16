using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VLS.Domain.DbModels
{
    public class Visitor : BaseEntity
    {
        public Visitor() 
        {
            VisitorCourses = new HashSet<VisitorCourse>();
            TransactionVisitors = new HashSet<TransactionVisitor>();
            EntryVisitors = new HashSet<TransactionVehicle>();
            ExitVisitors = new HashSet<TransactionVehicle>();
        }
        public long Visitor_ID { get; set; }

        [MaxLength(255)]
        public string FullName { get; set; } = null!;
        public int IDType_ID { get; set; }

        [MaxLength(50)]
        public string IDNumber { get; set; } = null!;

        [Column(TypeName = "date"), DataType(DataType.Date)]
        public DateOnly IDExpirationDate { get; set; }

        public int Country_ID { get; set; }
        public int? Company_ID { get; set; }

        public virtual Company? Company { get; set; }
        public virtual Reference? Country { get; set; }
        public virtual Reference? IDType { get; set; }
        public virtual ICollection<VisitorCourse>? VisitorCourses { get; set; }
        public virtual ICollection<TransactionVisitor>? TransactionVisitors { get; set; }
        public virtual ICollection<TransactionVehicle>? EntryVisitors { get; set; }
        public virtual ICollection<TransactionVehicle>? ExitVisitors { get; set; }
    }
}
