using System.ComponentModel.DataAnnotations;
using TeknorixTest.Models;

namespace TeknorixTest.Dtos
{
    public class CreateJobDto
    {
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 100 characters.")]
        public required string Title { get; set; }
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 100 characters.")]
        public required string Description { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Location ID must be a positive number.")]
        public int LocationId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Department ID must be a positive number.")]
        public int DepartmentId { get; set; }
        public required DateTime ClosingDate { get; set; }

    }
}
