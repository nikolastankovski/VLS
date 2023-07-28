using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VLS.Domain.DbModels
{
    [Table(nameof(OrganizationalUnit))]
    public class OrganizationalUnit : BaseEntity
    {
        public OrganizationalUnit()
        {
            Employees = new HashSet<Employee>();
            TransactionVisitors = new HashSet<TransactionVisitor>();
        }
        public int OrganizationalUnitId { get; set; }

        [MaxLength(50)]
        public string Code { get; set; } = null!;

        [MaxLength(255)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Employee>? Employees { get; set; }
        public virtual ICollection<TransactionVisitor>? TransactionVisitors { get; set; }
    }
}
