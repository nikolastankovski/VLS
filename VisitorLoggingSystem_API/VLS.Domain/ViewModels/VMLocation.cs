namespace VLS.Domain.ViewModels
{
    public class VMLocation : VMBaseEntity
    {
        public int Location_ID { get; set; }
        public string Name { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string? City { get; set; }
        public string? Municipality { get; set; }
        public string? Address { get; set; }
    }
}
