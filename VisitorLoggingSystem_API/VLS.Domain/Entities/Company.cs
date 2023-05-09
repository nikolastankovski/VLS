using System.ComponentModel.DataAnnotations;

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

        [MaxLength(255)]
        public string Name { get; set; } = null!;

        [MaxLength(255)]
        public string? Address { get; set; }

        [DataType(DataType.EmailAddress), MaxLength(100)]
        public string? Email { get; set; }

        [DataType(DataType.PhoneNumber), MaxLength(50)]
        public string? PhoneNumber { get; set; }

        [MaxLength(50)]
        public string? IDNumber { get; set; }

        public virtual ICollection<Visitor> Visitors { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
