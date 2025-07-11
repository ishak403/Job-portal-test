using TeknorixTest.Models;

namespace TeknorixTest.Dtos
{
    public class PaginatedJobResultDto 
    {
        public int TotalCount { get; set; }
        public List<JobListDto> Jobs { get; set; }

    }
}
