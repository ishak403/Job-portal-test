namespace TeknorixTest.Entities
{
    public class Job:BaseEntity
    {
        public required string Code {  get; set; }
        public required string Title {  get; set; }
        public required string Description { get; set; }
        public int LocationId { get; set; }
        public int DepartmentId { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime ClosingDate { get; set; }
    }
}
