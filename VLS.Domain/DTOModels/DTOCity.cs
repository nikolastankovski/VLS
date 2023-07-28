using System.ComponentModel.DataAnnotations;

namespace VLS.Domain.DTOModels
{
    public class DTOCity
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
    }
}
