using AutoPartsShop.Infrastructure.Database.Configuration;
using AutoPartsShop.Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPartsShop.Infrastructure.Database
{
    public class AutoPartsShopDbContext : DbContext
    {

        public AutoPartsShopDbContext(DbContextOptions<AutoPartsShopDbContext> options)
            : base(options) 
        { 

        }


        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Part> Parts { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<CarPart> CarParts { get; set; } = null!;
        public DbSet<Engine> Engines { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new PartConfiguration());
            

            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<CarPart>()
            .HasKey(cp => new { cp.CarId, cp.PartId });

            modelBuilder.Entity<CarPart>()
                .HasOne(cp => cp.Car)
                .WithMany(c => c.CarParts)
                .HasForeignKey(cp => cp.CarId);

            modelBuilder.Entity<CarPart>()
                .HasOne(cp => cp.Part)
                .WithMany(p => p.CarParts)
                .HasForeignKey(cp => cp.PartId);

        }



    }


}
