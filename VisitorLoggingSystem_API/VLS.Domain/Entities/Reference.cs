using VLS.Domain.Entities;

namespace VLS.Domain.Entities
{
    public class Reference : BaseEntity
    {
        public Reference() 
        {
            Locations = new HashSet<Location>();
            TransactionVisitors = new HashSet<TransactionVisitor>();
        }
        public int Reference_ID { get; set; }
        public int ReferenceType_ID { get; set; }
        public string Description { get; set; } = null!;
        public string Code { get; set; } = null!;

        public virtual ReferenceType? ReferenceType{ get; set; }
        public virtual ICollection<Location> Locations { get; set; }
        public virtual ICollection<TransactionVisitor> TransactionVisitors { get; set; }
    }
}
