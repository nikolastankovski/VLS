using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VLS.Domain.DbModels;

namespace VLS.Domain.DbModels
{
    [Table(nameof(ReferenceType))]
    public class ReferenceType : BaseEntity
    {
        public ReferenceType() 
        {
            References = new HashSet<Reference>();
        }
        public int ReferenceTypeId { get; set; }

        [MaxLength(50)]
        public string Code { get; set; } = null!;

        [MaxLength(255)]
        public string Description { get; set; } = null!;

        public virtual ICollection<Reference>? References { get; set; }
    }
}
