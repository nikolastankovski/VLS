namespace VLS.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public int Employee_ID { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string PersonalNumber { get; set; } = null!;
        public string OrganizationalUnitCode { get; set; } = null!;
        public bool IsActive { get; set; } = false;

        public virtual OrganizationalUnit? OrganizationalUnit { get; set; }
    }
}
