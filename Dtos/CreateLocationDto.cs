using System.ComponentModel.DataAnnotations;

namespace TeknorixTest.Models
{
    public class CreateLocationDto
    {
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 100 characters.")]
        public required string Title { get; set; }
        public string? City { get; set; }
        [StringLength(100, MinimumLength = 3, ErrorMessage = "State must be between 3 and 100 characters.")]
        public required string State { get; set; }
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Country must be between 3 and 100 characters.")]
        public required string Country { get; set; }
        public string? Zip { get; set; }
    }
}
