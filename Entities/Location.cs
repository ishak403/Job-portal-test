namespace TeknorixTest.Entities
{
    public class Location : BaseEntity
    {
        public required string Title {  get; set; }
        public required string? City {  get; set; }
        public required string State { get; set; }
        public required string Country { get; set; }
        public string? Zip { get; set; }

    }
}
