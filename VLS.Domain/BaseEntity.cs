using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VLS.Domain
{
    public abstract class BaseEntity
    {
        public int CreatedBy { get; set; }

        [Column(TypeName = "datetime2(3)"), DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }

        [Column(TypeName = "datetime2(3)"), DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get; set; }
    }
}