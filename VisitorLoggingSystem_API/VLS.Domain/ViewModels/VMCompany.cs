namespace VLS.Domain.ViewModels
{
    public class VMCompany : VMBaseEntity
    {
        public int CompanyId { get; set; }
        public string Name { get; set; } = null!;
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? IDNumber { get; set; }
    }
}
