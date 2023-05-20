using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VLS.Domain.DbModels;

namespace VLS.Domain.DbModels
{
    [Table(nameof(Location))]
    public class Location : BaseEntity
    {
        public Location() 
        {
            VisitorCourses = new HashSet<VisitorCourse>();
            TransactionVisitors = new HashSet<TransactionVisitor>();
            TransactionVehicles = new HashSet<TransactionVehicle>();
        }
        public int LocationId { get; set; }

        [MaxLength(255)]
        public string Name { get; set; } = null!;
        public int CountryId { get; set; }
        public int? CityId { get; set; }
        public int? MunicipalityId { get; set; }

        [MaxLength(255)]
        public string? Address { get; set; }

        public virtual ICollection<VisitorCourse>? VisitorCourses { get; set; }
        public virtual ICollection<TransactionVisitor>? TransactionVisitors { get; set; }
        public virtual ICollection<TransactionVehicle>? TransactionVehicles { get; set; }
        public virtual Reference? Country { get; set; }
        public virtual Reference? City { get; set; }
        public virtual Reference? Municipality { get; set; }
    }
}
