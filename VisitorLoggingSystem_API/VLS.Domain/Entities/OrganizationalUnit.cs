using System.ComponentModel.DataAnnotations;

namespace VLS.Domain.Entities
{
    public class OrganizationalUnit : BaseEntity
    {
        public OrganizationalUnit()
        {
            Employees = new HashSet<Employee>();
            TransactionVisitors = new HashSet<TransactionVisitor>();
        }
        public int OrganizationalUnit_ID { get; set; }

        [MaxLength(50)]
        public string Code { get; set; } = null!;

        [MaxLength(255)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Employee>? Employees { get; set; }
        public virtual ICollection<TransactionVisitor>? TransactionVisitors { get; set; }
    }
}
