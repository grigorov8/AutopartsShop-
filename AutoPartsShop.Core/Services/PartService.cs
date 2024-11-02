using AutoPartsShop.Core.Models;
using AutoPartsShop.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPartsShop.Core.Services
{
    public class PartService : IPartService
    {

        private readonly AutoShopDbContext _context;
        

        public PartService(AutoShopDbContext context)
        {
            _context = context;
        }



        public async Task<List<PartModel>> SearchPartsAsync(string partNumber)
        {

            var parts = await _context.Parts
                .Where(p => p.PartNumber == partNumber)
                .Select(p => new PartModel
                {
                    Id = p.Id,
                    PartNumber = p.PartNumber,
                    Name = p.Name,
                    Description = p.Description,
                    Manufacturer = p.Manufacturer,
                    ImageFileName = p.ImageFileName,
                    Price = p.Price
                })
                .ToListAsync(); 


            return parts; 


        }


     //   public Task<List<PartSearchByCarModel>> SearchPartsByCarAsync(string Make, string Model, int Year, decimal Displacement)
        
           
        


    }


}
