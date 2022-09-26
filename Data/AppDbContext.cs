using GraphQL_ASPNET_API.Data.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;

namespace GraphQL_ASPNET_API.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasOne(c => c.Brand)
                .WithMany(b => b.Cars)
                .HasForeignKey(c => c.BrandId);


            var bmw = new Brand()
            {
                Id = 1,
                Name = "BMW",
                Country = "Germany",
            };
            var tesla = new Brand()
            {
                Id = 2,
                Name = "Tesla",
                Country = "USA",
            };

            var vw = new Brand()
            {
                Id = 3,
                Name = "Volkswagen",
                Country = "Germany",
            };

            var porsche = new Brand()
            {
                Id = 4,
                Name = "Porsche",
                Country = "Germany",
            };

            var citroen = new Brand()
            {
                Id = 5,
                Name = "Citroen",
                Country = "France",
            };

            modelBuilder.Entity<Brand>()
                .HasData(bmw, tesla, vw, porsche, citroen);


            // data must be seeded like this - without new Car()
            // It is because of shadow properties (navigation properties)
            modelBuilder.Entity<Car>()
                .HasData(new
                {
                    Id = 1,
                    BrandId = 1,
                    Model = "M5",
                    ReleaseYear = 2020,
                    HorsePower = 350,
                    ImageUrl = "https://imgd.aeplcdn.com/1056x594/n/cw/ec/50723/m5-exterior-rear-view.jpeg",
                },
                new
                {
                    Id = 2,
                    BrandId = 1,
                    Model = "X7",
                    ReleaseYear = 2022,
                    HorsePower = 400,
                    ImageUrl = "https://imgd.aeplcdn.com/1056x594/cw/ec/28286/BMW-X7-Rear-view-145752.jpg",
                },
                new
                {
                    Id = 3,
                    BrandId = 2,
                    Model = "Model S",
                    ReleaseYear = 2019,
                    HorsePower = 500,
                    ImageUrl = "https://imgd.aeplcdn.com/1056x594/n/cw/ec/93821/exterior-right-front-three-quarter.jpeg",
                },
                new
                {
                    Id = 4,
                    BrandId = 3,
                    Model = "Tiguan",
                    ReleaseYear = 2019,
                    HorsePower = 300,
                    ImageUrl = "https://imgd.aeplcdn.com/1056x594/n/cw/ec/53123/tiguan-exterior-left-front-three-quarter.jpeg",
                },
                 new
                 {
                     Id = 5,
                     BrandId = 4,
                     Model = "Cayenne",
                     ReleaseYear = 2018,
                     HorsePower = 400,
                     ImageUrl = "https://imgd.aeplcdn.com/1056x594/n/cw/ec/32951/cayenne-exterior-right-rear-three-quarter.jpeg",
                 },
                  new
                  {
                      Id = 6,
                      BrandId = 4,
                      Model = "Taycan",
                      ReleaseYear = 2022,
                      HorsePower = 700,
                      ImageUrl = "https://imgd.aeplcdn.com/1056x594/n/cw/ec/45063/porsche-taycan-right-rear-three-quarter0.jpeg",
                  },
                  new
                  {
                      Id = 7,
                      BrandId = 5,
                      Model = "C3",
                      ReleaseYear = 2015,
                      HorsePower = 200,
                      ImageUrl = "https://imgd.aeplcdn.com/1056x594/n/cw/ec/103611/c3-exterior-left-rear-three-quarter.jpeg",
                  }
                );
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }

    }
}
