namespace VLS.Domain.Entities
{
    public class ApplicationFile : BaseEntity
    {
        public ApplicationFile()
        {
            VisitorCourses = new HashSet<VisitorCourse>();
        }
        public int ApplicationFile_ID { get; set; }
        public string Name { get; set; } = null!;
        public string Extension { get; set; } = null!;
        public string ContentType { get; set; } = null!;
        public byte[] Data { get; set; } = null!;

        public virtual ICollection<VisitorCourse> VisitorCourses { get; set; }

    }
}
