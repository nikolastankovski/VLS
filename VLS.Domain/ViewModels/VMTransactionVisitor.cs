namespace VLS.Domain.ViewModels
{
    public class VMTransactionVisitor : VMBaseEntity
    {
        public long TransactionVisitorId { get; set; }
        public long VisitorId { get; set; }
        public string? VehicleRegistrationNumber { get; set; }
        public string? VisiteeCode { get; set; }
        public string OrganizationUnitCode { get; set; } = null!;
        public int LocationId { get; set; }
        public string? SpecificPlace { get; set; }
        public DateTime EntryDateTime { get; set; }
        public DateTime? ExitDateTime { get; set; }
        public int ActivityId { get; set; }
        public bool Incident { get; set; } = false;
        public string? IncidentDescription { get; set; }

        public string? Visitor { get; set; }
        public string? Visitee { get; set; }
        public string? OrganizationalUnit { get; set; }
        public string? Location { get; set; }
        public string? Activity { get; set; }
    }
}
