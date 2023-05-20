using System.ComponentModel.DataAnnotations;

namespace VLS.Domain.DTOModels
{
    public class DTOLocation
    {
        public int LocationId { get; set; }

        [MaxLength(255)]
        public string Name { get; set; } = null!;
        public int CountryId { get; set; }
        public int? CityId { get; set; }
        public int? MunicipalityId { get; set; }

        [MaxLength(255)]
        public string? Address { get; set; }
    }
}
