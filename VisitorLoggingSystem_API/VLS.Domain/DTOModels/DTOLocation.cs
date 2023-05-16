using System.ComponentModel.DataAnnotations;

namespace VLS.Domain.DTOModels
{
    public class DTOLocation
    {
        public int Location_ID { get; set; }

        [MaxLength(255)]
        public string Name { get; set; } = null!;
        public int Country_ID { get; set; }
        public int? City_ID { get; set; }
        public int? Municipality_ID { get; set; }

        [MaxLength(255)]
        public string? Address { get; set; }
    }
}
