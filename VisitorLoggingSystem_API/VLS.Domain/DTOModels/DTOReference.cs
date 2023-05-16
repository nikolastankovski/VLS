using System.ComponentModel.DataAnnotations;

namespace VLS.Domain.DTOModels
{
    public class DTOReference
    {
        public int Reference_ID { get; set; }
        public int ReferenceType_ID { get; set; }

        [MaxLength(255)]
        public string Description { get; set; } = null!;

        [MaxLength(50)]
        public string Code { get; set; } = null!;
    }
}
