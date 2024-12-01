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

        public async Task AddPartAsync(PartModel partModel)
        {


            var part = new Part
            {
                Id = partModel.Id,
                Name = partModel.Name,
                PartNumber = partModel.PartNumber,
                Price = partModel.Price,
                Description = partModel.Description,
                Manufacturer = partModel.Manufacturer,
                Stock = partModel.Stock,
                CategoryId = partModel.SelectedCategoryId
            };

            await _repository.AddAsync(part);
            await _repository.SaveChangesAsync<Part>();

        }

       
        public async Task DeletePartAsync(int id)
        {

            await _repository.DeleteAsync<Part>(id);
            await _repository.SaveChangesAsync<Part>();

        }

        
        public async Task<IEnumerable<PartModel>> GetAllPartsAsync()
        {

            return await _repository.All<Part>()

                .Select(p => new PartModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    PartNumber = p.PartNumber,
                    Price = p.Price,
                    Description = p.Description,
                    Manufacturer = p.Manufacturer,
                    Stock= p.Stock,
                })
                .ToListAsync();

        }

       
        public async Task<PartModel?> GetPartByIdAsync(int id)
        {

            var part = await _repository.GetByIdAsync<Part>(id);

            if (part != null)
            {
                return new PartModel
                {
                    Id = part.Id,
                    Name = part.Name,
                    PartNumber = part.PartNumber,
                    Price = part.Price,
                    Description = part.Description,
                    Manufacturer = part.Manufacturer,
                    Stock = part.Stock,
                };
            }

            return null;
        }

       
        public async Task UpdatePartAsync(PartModel partModel)
        {

            var part = await _repository.GetByIdAsync<Part>(partModel.Id);

            if (part != null)
            {
                part.Name = partModel.Name;
                part.PartNumber = partModel.PartNumber;
                part.Price = partModel.Price;
                part.Description = partModel.Description;
                part.Manufacturer = partModel.Manufacturer;
                part.Stock = partModel.Stock;

                await _repository.SaveChangesAsync<Part>();
            }

            
        
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {

            return await _repository.All<Category>().ToListAsync();

        }


  



    }

}
