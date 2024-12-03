using AutoPartsShop.Core.Contracts;
using AutoPartsShop.Core.Models;
using AutoPartsShop.Infrastructure.Database.Common;
using AutoPartsShop.Infrastructure.Database.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
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


        public async Task<IEnumerable<CarModel>> GetAllCarsAsync()
        {

            return await _repository.All<Car>()

                .Select(c => new CarModel
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    Year = c.Year,
                    EngineCapacity = c.EngineCapacity,
                    Vin = c.Vin,
                   

                })
                .ToListAsync();

        }

        public async Task AddCarAsync(CarModel carModel)
        {


            var car = new Car
            {
                Id = carModel.Id,
                Make = carModel.Make,
                Model = carModel.Model,
                EngineCapacity = carModel.EngineCapacity,
                Year = carModel.Year,
                Vin = carModel.Vin,
               
            };

            await _repository.AddAsync(car);
            await _repository.SaveChangesAsync<CarModel>();

        }


        public async Task<CarModel?> GetCarByIdAsync(int id)
        {

            var car = await _repository.GetByIdAsync<Car>(id);

            if (car != null)
            {
                return new CarModel
                {
                    Id = car.Id,
                    Make = car.Make,
                    Model = car.Model,
                    Year = car.Year,
                    EngineCapacity = car.EngineCapacity,
                    Vin = car.Vin,

                };
            }

            return null;
        }




        public async Task UpdateCarAsync(CarModel carModel)
        {

            var car = await _repository.GetByIdAsync<Car>(carModel.Id);

            if (car != null)
            {
                car.Make = carModel.Make;
                car.Model = carModel.Model;
                car.Year = carModel.Year;
                car.EngineCapacity = carModel.EngineCapacity;
                car.Vin = carModel.Vin;


                await _repository.SaveChangesAsync<Car>();
            }

        }

        public async Task DeleteCarAsync(int id)
        {
       
                await _repository.DeleteAsync<Car>(id);
                await _repository.SaveChangesAsync<Car>();         

        }



    }


}
