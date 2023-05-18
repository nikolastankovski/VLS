using System.ComponentModel.DataAnnotations;

namespace VLS.Domain.DTOModels
{
    public class DTOEmployee
    {
        public int Employee_ID { get; set; }

        [MaxLength(50)]
        public string Code { get; set; } = null!;

        [MaxLength(255)]
        public string Name { get; set; } = null!;

        [MaxLength(20)]
        public string PersonalNumber { get; set; } = null!;

        [MaxLength(50)]
        public string OrganizationalUnitCode { get; set; } = null!;
        public bool IsActive { get; set; } = false;
    }
}
