using System.ComponentModel.DataAnnotations;

namespace GraphQL_ASPNET_API.Data.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
