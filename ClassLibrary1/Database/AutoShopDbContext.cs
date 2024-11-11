using AutoPartsShop.Infrastructure.Database.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace AutoPartsShop.Infrastructure.Database
{

    public class AutoShopDbContext : IdentityDbContext
    {



        public AutoShopDbContext(DbContextOptions<AutoShopDbContext> options)
            : base(options)
        {
        }




        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Part> Parts { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<CarPart> CarParts { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Car>().HasData(
                new Car { Id = 1, Make = "Audi", Model = "A4", Year = 2020, EngineCapacity = 2.0m, Vin = "WAUZZZ8K4AA123456" },
                new Car { Id = 2, Make = "BMW", Model = "3 Series", Year = 2019, EngineCapacity = 2.0m, Vin = "WBAVB33506KV12345" },
                new Car { Id = 3, Make = "Mercedes", Model = "C-Class", Year = 2021, EngineCapacity = 1.8m, Vin = "WDDGF81X98F123456" },
                new Car { Id = 4, Make = "Volkswagen", Model = "Golf", Year = 2018, EngineCapacity = 1.6m, Vin = "WVWZZZ1KZBW123456" },
                new Car { Id = 5, Make = "Skoda", Model = "Octavia", Year = 2022, EngineCapacity = 1.4m, Vin = "TMBJK73T0A0123456" }
            );


            
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Engine" },
                new Category { Id = 2, Name = "Brakes" },
                new Category { Id = 3, Name = "Suspension" },
                new Category { Id = 4, Name = "Filters" },
                new Category { Id = 5, Name = "Oils" }
            );

          
            modelBuilder.Entity<Part>().HasData(
                
                new Part { Id = 1, Name = "Air Filter", PartNumber = "AF123", Manufacturer = "MANN", Price = 20.5m, Stock = 5, CategoryId = 4, AverageRating = 4.5 },
                new Part { Id = 2, Name = "Fuel Filter", PartNumber = "FF123", Manufacturer = "MANN", Price = 15.0m, Stock = 4, CategoryId = 4, AverageRating = 4.2 },
                new Part { Id = 3, Name = "Oil Filter", PartNumber = "OF123", Manufacturer = "MANN", Price = 10.0m, Stock = 3, CategoryId = 4, AverageRating = 4.0 },

                
                new Part { Id = 4, Name = "Control Arm", PartNumber = "CA123", Manufacturer = "SuspensionPro", Price = 120.0m, Stock = 20, CategoryId = 3, AverageRating = 4.6 },

               
                new Part { Id = 5, Name = "Brake Pads", PartNumber = "BP123", Manufacturer = "BrakeKing", Price = 60.0m, Stock = 45, CategoryId = 2, AverageRating = 4.3 },
                new Part { Id = 6, Name = "Brake Discs", PartNumber = "BD123", Manufacturer = "BrakeKing", Price = 85.0m, Stock = 30, CategoryId = 2, AverageRating = 4.4 },

               
                new Part { Id = 7, Name = "Piston", PartNumber = "PI123", Manufacturer = "EngineTech", Price = 220.0m, Stock = 15, CategoryId = 1, AverageRating = 4.5 }
            );

           
            modelBuilder.Entity<CarPart>().HasData(
               
                new CarPart { Id = 1, CarId = 1, PartId = 1 },
                new CarPart { Id = 2, CarId = 2, PartId = 2 },
                new CarPart { Id = 3, CarId = 3, PartId = 3 },

                
                new CarPart { Id = 4, CarId = 4, PartId = 4 },

              
                new CarPart { Id = 5, CarId = 1, PartId = 5 },
                new CarPart { Id = 6, CarId = 2, PartId = 6 },

                
                new CarPart { Id = 7, CarId = 3, PartId = 7 }
            );

            
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Engine Oil 5W-30", ProductNumber = "EO530", Manufacturer = "Castrol", Price = 45.0m, StockQuantity = 10, CategoryId = 5, Description = "High quality engine oil for better performance." },
                new Product { Id = 2, Name = "Transmission Oil", ProductNumber = "TO123", Manufacturer = "Castrol", Price = 55.0m, StockQuantity = 8, CategoryId = 5, Description = "Special transmission oil for smoother shifting." },
                new Product { Id = 3, Name = "Hydraulic Oil", ProductNumber = "HO123", Manufacturer = "Castrol", Price = 30.0m, StockQuantity = 7, CategoryId = 5, Description = "Hydraulic oil for industrial machinery." }
            );



        }



    }



}



