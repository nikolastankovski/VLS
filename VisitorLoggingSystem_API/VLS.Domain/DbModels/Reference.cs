using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VLS.Domain.DbModels;

namespace VLS.Domain.DbModels
{
    [Table(nameof(Reference))]
    public class Reference : BaseEntity
    {
        public Reference() 
        {
            LocationCountries = new HashSet<Location>();
            VisitorCountries = new HashSet<Visitor>();
            Cities = new HashSet<Location>();
            Municipalities = new HashSet<Location>();
            TransactionVisitors = new HashSet<TransactionVisitor>();
        }
        public int ReferenceId { get; set; }
        public int ReferenceTypeId { get; set; }

        [MaxLength(255)]
        public string Description { get; set; } = null!;

        [MaxLength(50)]
        public string Code { get; set; } = null!;

        public virtual ReferenceType? ReferenceType { get; set; }
        public virtual ICollection<Location>? LocationCountries { get; set; }
        public virtual ICollection<Location>? Cities { get; set; }
        public virtual ICollection<Location>? Municipalities { get; set; }
        public virtual ICollection<Visitor>? VisitorCountries { get; set; }
        public virtual ICollection<Visitor>? IDTypes { get; set; }
        public virtual ICollection<TransactionVisitor>? TransactionVisitors { get; set; }
    }
}
