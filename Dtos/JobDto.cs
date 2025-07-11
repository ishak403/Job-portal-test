using TeknorixTest.Models;

namespace TeknorixTest.Dtos
{
    public class JobDto : BaseDto
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public LocationDto LocationDto { get; set; }
        public DepartmentDto DepartmentDto { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime ClosingDate { get; set; }

    }
}
