using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VLS.Domain.DTOModels
{
    public class DTOVisitor
    {
        public long Visitor_ID { get; set; }

        [MaxLength(255)]
        public string FullName { get; set; } = null!;
        public int IDType_ID { get; set; }

        [MaxLength(50)]
        public string IDNumber { get; set; } = null!;

        [Column(TypeName = "date"), DataType(DataType.Date)]
        public DateOnly IDExpirationDate { get; set; }

        public int Country_ID { get; set; }
        public int? Company_ID { get; set; }
    }
}
