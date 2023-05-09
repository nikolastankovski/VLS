using System.ComponentModel.DataAnnotations;
using VLS.Domain.Entities;

namespace VLS.Domain.Entities
{
    public class TransactionVisitor : BaseEntity
    {

        public long TransactionVisitor_ID { get; set; }
        public long Visitor_ID { get; set; }

        [MaxLength(50)]
        public string? VehicleRegistrationNumber { get; set; }

        [MaxLength(50)]
        public string? VisiteeCode { get; set; }

        [MaxLength(50)]
        public string OrganizationUnitCode { get; set; } = null!;
        public int Location_ID { get; set; }

        [MaxLength(255)]
        public string? SpecificPlace { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime EntryDateTime { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ExitDateTime { get; set; }
        public int Activity_ID { get; set; }
        public bool Incident { get; set; } = false;
        public string? IncidentDescription { get; set; }

        public virtual Visitor? Visitor { get; set; }
        public virtual Employee? Visitee { get; set; }
        public virtual OrganizationalUnit? OrganizationalUnit { get; set; }
        public virtual Location? Location { get; set; }
        public virtual Reference? Activity { get; set; }
    }
}
