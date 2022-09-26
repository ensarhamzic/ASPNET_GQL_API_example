namespace GraphQL_ASPNET_API.GraphQL.Cars
{
    public class UpdateCarInput
    {
        public int Id { get; set; }
        public string Model { get; set; } = string.Empty;
        public int ReleaseYear { get; set; }
        public int HorsePower { get; set; }
        public string? ImageUrl { get; set; }
        public int BrandId { get; set; }
    }
}
