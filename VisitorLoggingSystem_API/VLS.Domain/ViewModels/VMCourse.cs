namespace VLS.Domain.ViewModels
{
    public class VMCourse : VMBaseEntity
    {
        public int Course_ID { get; set; }
        public string Name { get; set; } = null!;
        public string ShortName { get; set; } = null!;
        public bool IsMandatory { get; set; } = false;
    }
}
