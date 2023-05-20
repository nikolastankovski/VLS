using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VLS.Domain.DbModels
{
    [Table(nameof(TransactionVehicle))]
    public class TransactionVehicle : BaseEntity
    {
        public long TransactionVehicleId { get; set; }
        public int LocationId { get; set; }
        public long VehicleId { get; set; }

        [Column(TypeName = "datetime2(3)"), DataType(DataType.DateTime)]
        public DateTime EntryDateTime { get; set; }

        [Column(TypeName = "datetime2(3)"), DataType(DataType.DateTime)]
        public DateTime? ExitDateTime { get; set; }
        public long EntryVisitorId { get; set; }
        public long? ExitVisitorId { get; set; }

        public virtual Location? Location { get; set; }
        public virtual Vehicle? Vehicle { get; set; }
        public virtual Visitor? EntryVisitor { get; set; }
        public virtual Visitor? ExitVisitor { get; set; }
    }
}
