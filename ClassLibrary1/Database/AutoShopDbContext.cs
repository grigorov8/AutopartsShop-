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


            modelBuilder.Entity<Car>()
                .Property(c => c.EngineCapacity)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Part>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");



        }



    }



}



