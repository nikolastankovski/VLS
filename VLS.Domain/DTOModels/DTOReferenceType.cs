using System.ComponentModel.DataAnnotations;

namespace VLS.Domain.DTOModels
{
    public class DTOReferenceType
    {
        public int ReferenceTypeId { get; set; }

        [MaxLength(50)]
        public string Code { get; set; } = null!;

        [MaxLength(255)]
        public string Description { get; set; } = null!;

    }
}
