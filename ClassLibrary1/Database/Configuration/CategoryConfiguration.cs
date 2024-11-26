using AutoPartsShop.Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsShop.Infrastructure.Database.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { Id = 2, Name = "Engine" },
                new Category { Id = 1, Name = "Filters" },
                new Category { Id = 3, Name = "Brake" }
            );

        }

    }

}
