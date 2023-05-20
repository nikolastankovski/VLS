using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VLS.Domain.DbModels
{
    [Table(nameof(Country))]
    public class Country : BaseEntity
    {
        public Country() 
        {
            Cities = new HashSet<City>();    
        }
        public int CountryId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [MaxLength(10)]
        public string Code { get; set; } = null!;

        [MaxLength(50)]
        public string Region { get; set; } = null!;

        [DataType(DataType.Url), MaxLength(255)]
        public string? FlagURL { get; set; }
        public bool IsEUMember { get; set; } = false;

        [MaxLength(10)]
        public string? PhoneCode { get; set; }
        public virtual ICollection<City>? Cities { get; set; }
    }
}
