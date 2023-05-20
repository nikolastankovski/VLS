using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VLS.Domain.DbModels
{
    [Table(nameof(City))]
    public class City : BaseEntity
    {
        public int CityId { get; set; }
        public int CountryId { get; set; }

        [MaxLength(255)]
        public string Name { get; set; } = null!;

        [DataType(DataType.PostalCode), MaxLength(25)]
        public string? PostalCode { get; set; }

        [MaxLength(25)]
        public string? Longitude { get; set; }

        [MaxLength(25)]
        public string? Latitude { get; set; }

        public virtual Country? Country { get; set; }
    }
}
