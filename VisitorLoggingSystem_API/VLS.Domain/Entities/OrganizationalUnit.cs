namespace VLS.Domain.Entities
{
    public class OrganizationalUnit : BaseEntity
    {
        public OrganizationalUnit()
        {
            Employees = new HashSet<Employee>();
        }
        public int OrganizationalUnit_ID { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
