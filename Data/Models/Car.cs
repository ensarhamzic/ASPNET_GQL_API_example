using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;

namespace GraphQL_ASPNET_API.Data.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        public string Model { get; set; } = string.Empty;
        public int ReleaseYear { get; set; }
        public int HorsePower { get; set; }
        public string? ImageUrl { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
