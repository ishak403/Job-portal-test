using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TeknorixTest.Models;

namespace TeknorixTest.Dtos
{
    public class JobFilterDto
    {
        [StringLength(100, ErrorMessage = "Search query cannot exceed 100 characters.")]
        public string? Q { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Page number must be at least 1.")]
        public int PageNo { get; set; } = 1;

        [Range(1, 100, ErrorMessage = "Page size must be between 1 and 100.")]
        public int PageSize { get; set; } = 10;

        [Range(1, int.MaxValue, ErrorMessage = "Location ID must be a positive number.")]
        public int? LocationId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Department ID must be a positive number.")]
        public int? DepartmentId { get; set; }
    }
}