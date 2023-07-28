using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using VLS.Domain.DbModels;

namespace VLS.Domain.ViewModels
{
    public class VMVisitor : VMBaseEntity
    {
        public long VisitorId { get; set; }
        public string FullName { get; set; } = null!;
        public int IDTypeId { get; set; }
        public string IDNumber { get; set; } = null!;
        public DateOnly IDExpirationDate { get; set; }
        public int CountryId { get; set; }
        public int? CompanyId { get; set; }

        public string? Company { get; set; }
        public string? Country { get; set; }
        public string? IDType { get; set; }
        public List<string> VisitorCourses { get; set; } = new List<string>();
    }
}
