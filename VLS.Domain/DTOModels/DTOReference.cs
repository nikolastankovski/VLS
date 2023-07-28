using System.ComponentModel.DataAnnotations;

namespace VLS.Domain.DTOModels
{
    public class DTOReference
    {
        public int ReferenceId { get; set; }
        public int ReferenceTypeId { get; set; }

        [MaxLength(255)]
        public string Description { get; set; } = null!;

        [MaxLength(50)]
        public string Code { get; set; } = null!;
    }
}
