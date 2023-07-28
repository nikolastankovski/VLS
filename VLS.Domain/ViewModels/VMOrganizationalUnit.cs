namespace VLS.Domain.ViewModels
{
    public class VMOrganizationalUnit : VMBaseEntity
    {
        public int OrganizationalUnitId { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
    }
}
