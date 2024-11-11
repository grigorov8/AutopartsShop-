using AutoPartsShop.Core.Models;
using AutoPartsShop.Infrastructure.Database.Common;
using AutoPartsShop.Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore;



namespace AutoPartsShop.Core.Services
{
    public class PartService : IPartService
    {

        private readonly IRepository _repository;
        

        public PartService(IRepository repository)
        {

            _repository = repository;

        }



        public async Task<List<PartModel>> SearchPartsAsync(string partNumber)
        {

            var parts = await _repository
                .All<Part>()
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
