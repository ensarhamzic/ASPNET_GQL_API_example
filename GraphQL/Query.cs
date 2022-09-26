using GraphQL_ASPNET_API.Data;
using GraphQL_ASPNET_API.Data.Models;

namespace GraphQL_ASPNET_API.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Brand> GetBrand([ScopedService] AppDbContext dbContext)
        {
            return dbContext.Brands;
        }
        
        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Car> GetCar([ScopedService] AppDbContext dbContext)
        {
            return dbContext.Cars;
        }
    }
}
