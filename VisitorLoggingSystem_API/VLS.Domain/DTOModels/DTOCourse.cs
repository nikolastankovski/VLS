using System.ComponentModel.DataAnnotations;

namespace VLS.Domain.DTOModels
{
    public class DTOCourse
    {
        public int Course_ID { get; set; }

        [MaxLength(255)]
        public string Name { get; set; } = null!;

        [MaxLength(50)]
        public string ShortName { get; set; } = null!;
        public bool IsMandatory { get; set; } = false;
    }
}
