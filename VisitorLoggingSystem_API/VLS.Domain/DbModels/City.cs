using System.ComponentModel.DataAnnotations;

namespace VLS.Domain.DbModels
{
    public class City : BaseEntity
    {
        public int City_ID { get; set; }
        public int Country_ID { get; set; }

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
