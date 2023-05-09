using System.ComponentModel.DataAnnotations;

namespace VLS.Domain
{
    public abstract class BaseEntity
    {
        public int CreatedBy { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get; set; }
    }
}