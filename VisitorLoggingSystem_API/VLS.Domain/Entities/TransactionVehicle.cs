using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VLS.Domain.Entities
{
    public class TransactionVehicle : BaseEntity
    {

        public long TransactionVehicle_ID { get; set; }
        public int Location_ID { get; set; }
        public long Vehicle_ID { get; set; }

        [Column(TypeName = "datetime2(3)"), DataType(DataType.DateTime)]
        public DateTime EntryDateTime { get; set; }

        [Column(TypeName = "datetime2(3)"), DataType(DataType.DateTime)]
        public DateTime? ExitDateTime { get; set; }
        public long EntryVisitor_ID { get; set; }
        public long? ExitVisitor_ID { get; set; }

        public virtual Location? Location { get; set; }
        public virtual Vehicle? Vehicle { get; set; }
        public virtual Visitor? EntryVisitor { get; set; }
        public virtual Visitor? ExitVisitor { get; set; }
    }
}
