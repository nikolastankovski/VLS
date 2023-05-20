namespace VLS.Domain.ViewModels
{
    public class VMVehicle : VMBaseEntity
    {
        public long VehicleId { get; set; }
        public int CompanyId { get; set; }
        public string RegistrationNumber { get; set; } = null!;
        public DateOnly TechnicalCorrectnessExpireDate { get; set; }
        public string? Description { get; set; }
        public string? Company { get; set; }

    }
}
