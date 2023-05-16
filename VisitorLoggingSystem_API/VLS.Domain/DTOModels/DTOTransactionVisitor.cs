using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VLS.Domain.DTOModels
{
    public class DTOTransactionVisitor
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

        [Column(TypeName = "datetime2(3)"), DataType(DataType.DateTime)]
        public DateTime EntryDateTime { get; set; }

        [Column(TypeName = "datetime2(3)"), DataType(DataType.DateTime)]
        public DateTime? ExitDateTime { get; set; }
        public int Activity_ID { get; set; }
        public bool Incident { get; set; } = false;
        public string? IncidentDescription { get; set; }
    }
}
