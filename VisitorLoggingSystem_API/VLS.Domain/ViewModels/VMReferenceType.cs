using VLS.Domain.DbModels;

namespace VLS.Domain.ViewModels
{
    public class VMReferenceType : VMBaseEntity
    {
        public int ReferenceTypeId { get; set; }
        public string Code { get; set; } = null!;
        public string Description { get; set; } = null!;

        public List<Reference> References { get; set; } = new List<Reference>();
    }
}
