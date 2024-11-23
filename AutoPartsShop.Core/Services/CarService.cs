using AutoPartsShop.Core.Contracts;
using AutoPartsShop.Core.Models;
using AutoPartsShop.Infrastructure.Database.Common;
using AutoPartsShop.Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore;


namespace AutoPartsShop.Core.Services
{
    public class CarService : ICarService
    {


        private readonly IRepository _repository;


        public CarService(IRepository repository)
        {

            _repository = repository;

        }


        public async Task<CarModel> SearchCarByVin(string vin)
        {

            var car = await _repository
                .All<Car>()
                .Where(c => c.Vin == vin)
                .Select(c => new CarModel
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    Year = c.Year,
                    EngineCapacity = c.EngineCapacity,
                    Vin = c.Vin,
                    Image = c.Image,
                    Parts = c.CarParts.Select(cp => new PartModel
                    {
                        Id = cp.Part.Id,
                        PartNumber = cp.Part.PartNumber,
                        Name = cp.Part.Name,
                        Manufacturer = cp.Part.Manufacturer,
                        Price = cp.Part.Price,
                        ImageFileName = cp.Part.ImageFileName
                    }).ToList()
                })
                .FirstOrDefaultAsync();


            return car;

        }
    }

}
