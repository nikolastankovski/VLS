using VLS.Domain.DbModels;

namespace VLS.Domain.ViewModels
{
    public class VMEmployee : VMBaseEntity
    {
        public int EmployeeId { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string PersonalNumber { get; set; } = null!;
        public string OrganizationalUnitCode { get; set; } = null!;
        public bool IsActive { get; set; } = false;
        public string OrganizationalUnit { get; set; } = string.Empty;
    }
}
