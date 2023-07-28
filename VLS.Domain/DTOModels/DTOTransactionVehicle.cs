using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VLS.Domain.DTOModels
{
    public class DTOTransactionVehicle
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
    }
}
