namespace VLS.Domain.Entities
{
    public class Company : BaseEntity
    {
        public Company() 
        {
            Visitors = new HashSet<Visitor>();
            Vehicles = new HashSet<Vehicle>();
        }
        public int Company_ID { get; set; }
        public string Name { get; set; } = null!;
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? IDNumber { get; set; }

        public virtual ICollection<Visitor> Visitors { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
