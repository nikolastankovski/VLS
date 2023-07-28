using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VLS.Domain.DTOModels
{
    public class DTOVehicle
    {
        public long VehicleId { get; set; }
        public int CompanyId { get; set; }

        [MaxLength(50)]
        public string RegistrationNumber { get; set; } = null!;

        [Column(TypeName = "date"), DataType(DataType.Date)]
        public DateOnly TechnicalCorrectnessExpireDate { get; set; }

        [MaxLength(255)]
        public string? Description { get; set; }
    }
}
