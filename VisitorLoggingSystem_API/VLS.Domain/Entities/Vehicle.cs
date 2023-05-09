namespace VLS.Domain.Entities
{
    public class Vehicle : BaseEntity
    {
        public long Vehicle_ID { get; set; }
        public int Company_ID { get; set; }
        public string RegistrationNumber { get; set; } = null!;
        public DateTime TechnicalCorrectnessExpireDate { get; set; }
        public string? Description { get; set; }

        public virtual Company? Company { get; set; }
    }
}
