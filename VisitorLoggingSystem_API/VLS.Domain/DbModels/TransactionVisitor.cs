using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VLS.Domain.DbModels
{
    [Table(nameof(TransactionVisitor))]
    public class TransactionVisitor : BaseEntity
    {
        public long TransactionVisitorId { get; set; }
        public long VisitorId { get; set; }

        [MaxLength(50)]
        public string? VehicleRegistrationNumber { get; set; }

        [MaxLength(50)]
        public string? VisiteeCode { get; set; }

        [MaxLength(50)]
        public string OrganizationUnitCode { get; set; } = null!;
        public int LocationId { get; set; }

        [MaxLength(255)]
        public string? SpecificPlace { get; set; }

        [Column(TypeName = "datetime2(3)"), DataType(DataType.DateTime)]
        public DateTime EntryDateTime { get; set; }

        [Column(TypeName = "datetime2(3)"), DataType(DataType.DateTime)]
        public DateTime? ExitDateTime { get; set; }
        public int ActivityId { get; set; }
        public bool Incident { get; set; } = false;
        public string? IncidentDescription { get; set; }

        public virtual Visitor? Visitor { get; set; }
        public virtual Employee? Visitee { get; set; }
        public virtual OrganizationalUnit? OrganizationalUnit { get; set; }
        public virtual Location? Location { get; set; }
        public virtual Reference? Activity { get; set; }
    }
}
