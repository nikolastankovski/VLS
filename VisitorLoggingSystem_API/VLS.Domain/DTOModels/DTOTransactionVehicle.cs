using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VLS.Domain.DTOModels
{
    public class DTOTransactionVehicle
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
    }
}
