namespace GraphQL_ASPNET_API.GraphQL.Cars
{
    public class AddCarInput
    {
        public int BrandId { get; set; }
        public string Model { get; set; } = string.Empty;
        public int ReleaseYear { get; set; }
        public int HorsePower { get; set; }
        public string? ImageUrl { get; set; }
    }
}
