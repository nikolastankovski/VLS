using System.ComponentModel.DataAnnotations;

namespace VLS.Domain.Entities
{
    public class Vehicle : BaseEntity
    {
        public long Vehicle_ID { get; set; }
        public int Company_ID { get; set; }

        [MaxLength(50)]
        public string RegistrationNumber { get; set; } = null!;

        [DataType(DataType.Date)]
        public DateTime TechnicalCorrectnessExpireDate { get; set; }

        [MaxLength(255)]
        public string? Description { get; set; }

        public virtual Company? Company { get; set; }
    }
}
