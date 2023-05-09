using VLS.Domain.Entities;

namespace VLS.Domain.Entities
{
    public class ReferenceType : BaseEntity
    {
        public ReferenceType() 
        {
            References = new HashSet<Reference>();
        }
        public int ReferenceType_ID { get; set; }
        public string Code { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<Reference> References { get; set; }
    }
}
