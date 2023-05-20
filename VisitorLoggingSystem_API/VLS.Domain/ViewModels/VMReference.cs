namespace VLS.Domain.ViewModels
{
    public class VMReference : VMBaseEntity
    {
        public int ReferenceId { get; set; }
        public int ReferenceTypeId { get; set; }
        public string Description { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? ReferenceType { get; set; }
    }
}
