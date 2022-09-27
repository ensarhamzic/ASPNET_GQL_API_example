using GraphQL_ASPNET_API.Data;
using GraphQL_ASPNET_API.Data.Models;
using GraphQL_ASPNET_API.GraphQL.Brands;
using GraphQL_ASPNET_API.GraphQL.Cars;

namespace GraphQL_ASPNET_API.GraphQL
{
    public class Mutation
    {

        // CREATE METHODS
        // ....................................................................................
        [UseDbContext(typeof(AppDbContext))]
        public Brand AddBrand(AddBrandInput input, [ScopedService] AppDbContext context)
        {
            var brand = new Brand()
            {
                Name = input.Name,
                Country = input.Country
            };

            context.Brands.Add(brand);
            context.SaveChanges();

            return brand;
        }
        
        [UseDbContext(typeof(AppDbContext))]
        public Car AddCar(AddCarInput input, [ScopedService] AppDbContext context)
        {
            if (!context.Brands.Any(b => b.Id == input.BrandId)) throw new Exception("Brand does not exist");
            var car = new Car()
            {
                Model = input.Model,
                ReleaseYear = input.ReleaseYear,
                HorsePower = input.HorsePower,
                ImageUrl = input.ImageUrl,
                BrandId = input.BrandId,
            };

            context.Cars.Add(car);
            context.SaveChanges();

            return car;
        }

        // UPDATE METHODS
        // ....................................................................................
        [UseDbContext(typeof(AppDbContext))]
        public Brand UpdateBrand(UpdateBrandInput input, [ScopedService] AppDbContext context)
        {
            var brand = context.Brands.FirstOrDefault(b => b.Id == input.Id);
            if (brand == null) throw new Exception("Brand not found");
            brand.Name = input.Name;
            brand.Country = input.Country;

            context.SaveChanges();

            return brand;
        }

        [UseDbContext(typeof(AppDbContext))]
        public Car UpdateCar(UpdateCarInput input, [ScopedService] AppDbContext context)
        {
            var car = context.Cars.FirstOrDefault(c => c.Id == input.Id);
            if (car == null) throw new Exception("Car not found");
            car.Model = input.Model;
            car.HorsePower = input.HorsePower;
            car.ReleaseYear = input.ReleaseYear;
            car.ImageUrl = input.ImageUrl;
            car.BrandId = car.BrandId;
            car.Brand = car.Brand;

            context.SaveChanges();

            return car;
        }

        // DELETE METHODS
        // ....................................................................................
        [UseDbContext(typeof(AppDbContext))]
        public Brand RemoveBrand(RemoveInput input, [ScopedService] AppDbContext context)
        {
            var brand = context.Brands.FirstOrDefault(b => b.Id == input.Id);
            if(brand == null) throw new Exception("Brand not found");
            context.Remove(brand);
            context.SaveChanges();

            return brand;
        }
        
        [UseDbContext(typeof(AppDbContext))]
        public Car RemoveCar(RemoveInput input, [ScopedService] AppDbContext context)
        {
            var car = context.Cars.FirstOrDefault(c => c.Id == input.Id);
            if(car == null) throw new Exception("Car not found");

            context.Remove(car);
            context.SaveChanges();

            return car;
        }
    }
}
