using System.ComponentModel.DataAnnotations;

namespace VLS.Domain.ViewModels
{
    public class VMCity : VMBaseEntity
    {
        public int CityId { get; set; }
        public string Country { get; set; } = null!;

        [MaxLength(255)]
        public string Name { get; set; } = null!;

        [DataType(DataType.PostalCode), MaxLength(25)]
        public string? PostalCode { get; set; }

        [MaxLength(25)]
        public string? Longitude { get; set; }

        [MaxLength(25)]
        public string? Latitude { get; set; }
    }
}
