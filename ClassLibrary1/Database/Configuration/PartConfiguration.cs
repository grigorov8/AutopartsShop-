using AutoPartsShop.Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPartsShop.Infrastructure.Database.Configuration
{
    public class PartConfiguration : IEntityTypeConfiguration<Part>
    {

        private Part[] oilFilterparts =
        {
            new Part
            {
                Id = 1,
                Name = "Oil Filter",
                PartNumber = "W 719/30",
                Manufacturer = "MANN",
                Price = 10.99m,
                Description = "High-performance oil filter for vehicles.",
                Stock = 10,
                ImageFileName = "Oil-Filter.jpg",
                CategoryId = 1
            },
            new Part
            {
                Id = 2,
                Name = "Oil Filter",
                PartNumber = "HU 719/6 X",
                Manufacturer = "MANN",
                Price = 12.49m,
                Description = "Long-life oil filter suitable for modern engines.",
                Stock = 5,
                ImageFileName = "Oil-Filter.jpg",
                CategoryId = 1
            },
            new Part
            {
                Id = 3,
                Name = "Oil Filter",
                PartNumber = "W 712",
                Manufacturer = "MANN",
                Price = 8.99m,
                Description = "Reliable oil filter for optimal engine protection.",
                Stock = 3,
                ImageFileName = "Oil-Filter.jpg",
                CategoryId = 1
            }



        
        };


        private Part[] airFilterParts =
        {
            new Part
            {
                Id = 4,
                Name = "Air Filter",
                PartNumber = "C 25 024",
                Manufacturer = "MANN",
                Price = 15.99m,
                Description = "High-efficiency air filter for improved engine performance.",
                Stock = 10,
                ImageFileName = "Air-Filter.jpg",
                CategoryId = 1
            },
            new Part
            {
                Id = 5,
                Name = "Air Filter",
                PartNumber = "C 18 001",
                Manufacturer = "MANN",
                Price = 13.49m,
                Description = "Durable air filter for superior filtration and protection.",
                Stock = 10,
                ImageFileName = "Air-Filter.jpg",
                CategoryId = 1
            },
            new Part
            {
                Id = 6,
                Name = "Air Filter",
                PartNumber = "C 37 153",
                Manufacturer = "MANN",
                Price = 18.99m,
                Description = "Advanced air filter for enhanced air flow and engine efficiency.",
                Stock = 20,
                ImageFileName = "Air-Filter.jpg",
                CategoryId = 1
            }

        };



        private Part[] fuelFilterParts =
        {
            new Part
            {
                Id = 7,
                Name = "Fuel Filter",
                PartNumber = "F 00 000 000",
                Manufacturer = "MANN",
                Price = 25.99m,
                Description = "High-performance fuel filter for efficient fuel filtration.",
                Stock = 20,
                ImageFileName = "Fuel-Filter.jpg",
                CategoryId = 1
            },
            new Part
            {
                Id = 8,
                Name = "Fuel Filter",
                PartNumber = "F 00 000 001",
                Manufacturer = "MANN",
                Price = 28.49m,
                Description = "Durable fuel filter for reliable performance and protection.",
                Stock = 15,
                ImageFileName = "Fuel-Filter.jpg",
                CategoryId = 1
            },
            new Part
            {
                Id = 9,
                Name = "Fuel Filter",
                PartNumber = "F 00 000 002",
                Manufacturer = "MANN",
                Price = 30.99m,
                Description = "Advanced fuel filter for optimal engine efficiency.",
                Stock = 10,
                ImageFileName = "Fuel-Filter.jpg",
                CategoryId = 1
            }
        };



        public void Configure(EntityTypeBuilder<Part> builder)
        {

            builder.HasData(oilFilterparts);
            builder.HasData(airFilterParts);
            builder.HasData(fuelFilterParts);

        }

    }
}
