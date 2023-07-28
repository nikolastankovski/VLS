using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VLS.Domain.DbModels
{
    [Table(nameof(Employee))]
    public class Employee : BaseEntity
    {
        public Employee() 
        {
            TransactionVisitors = new HashSet<TransactionVisitor>();
        }
        public int EmployeeId { get; set; }

        [MaxLength(50)]
        public string Code { get; set; } = null!;

        [MaxLength(255)]
        public string Name { get; set; } = null!;

        [MaxLength(20)]
        public string PersonalNumber { get; set; } = null!;

        [MaxLength(50)]
        public string OrganizationalUnitCode { get; set; } = null!;
        public bool IsActive { get; set; } = false;

        public virtual OrganizationalUnit? OrganizationalUnit { get; set; }
        public virtual ICollection<TransactionVisitor>? TransactionVisitors { get; set; }
    }
}
