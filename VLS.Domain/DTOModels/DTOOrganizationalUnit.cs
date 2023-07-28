using System.ComponentModel.DataAnnotations;

namespace VLS.Domain.DTOModels
{
    public class DTOOrganizationalUnit
    {
        public int OrganizationalUnitId { get; set; }

        [MaxLength(50)]
        public string Code { get; set; } = null!;

        [MaxLength(255)]
        public string Name { get; set; } = null!;
    }
}
