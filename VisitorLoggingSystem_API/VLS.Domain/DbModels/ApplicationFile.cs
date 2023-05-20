using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VLS.Domain.DbModels
{
    [Table(nameof(ApplicationFile))]
    public class ApplicationFile : BaseEntity
    {
        public ApplicationFile()
        {
            VisitorCourses = new HashSet<VisitorCourse>();
        }
        public int ApplicationFileId { get; set; }

        [MaxLength(255)]
        public string Name { get; set; } = null!;

        [MaxLength(10)]
        public string Extension { get; set; } = null!;

        [MaxLength(255)]
        public string ContentType { get; set; } = null!;
        public byte[] Data { get; set; } = null!;

        public virtual ICollection<VisitorCourse>? VisitorCourses { get; set; }

    }
}
