namespace TeknorixTest.Models
{
    public class LocationDto : BaseDto
    {
        public required string Title { get; set; }
        public string? City { get; set; }
        public required string State { get; set; }
        public required string Country { get; set; }
        public string? Zip { get; set; }
    }
}
