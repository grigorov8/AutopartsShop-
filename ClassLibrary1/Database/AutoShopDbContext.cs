using AutoPartsShop.Infrastructure.Database.Configuration;
using AutoPartsShop.Infrastructure.Database.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


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

            


        }

       
        



    }



}



