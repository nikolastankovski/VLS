using VLS.Domain.DbModels;

namespace VLS.Domain.ViewModels
{
    public class VMTransactionVehicle : VMBaseEntity
    {
        public long TransactionVehicleId { get; set; }
        public int LocationId { get; set; }
        public long VehicleId { get; set; }
        public DateTime EntryDateTime { get; set; }
        public DateTime? ExitDateTime { get; set; }
        public long EntryVisitorId { get; set; }
        public long? ExitVisitorId { get; set; }

        public string? Location { get; set; }
        public string? Vehicle { get; set; }
        public string? EntryVisitor { get; set; }
        public string? ExitVisitor { get; set; }
    }
}
