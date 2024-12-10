using AutoPartsShop.Core.Models;
using AutoPartsShop.Core.Services;
using AutoPartsShop.Infrastructure.Database.Common;
using AutoPartsShop.Infrastructure.Database.Models;
using Moq;
using NUnit.Framework;



namespace AutoPartsShop.Test.Services
{

    [TestFixture]
    public class CarTests
    {

        private Mock<IRepository> _repositoryMock;
        private CarService _carService;

        [SetUp]
        public void SetUp()
        {
            _repositoryMock = new Mock<IRepository>();
            _carService = new CarService(_repositoryMock.Object);
        }



        [Test]
        public async Task AddCarAsync_ShouldAddCarToRepository()
        {
           

            var carModel = new CarModel
            {
                Id = 1,
                Make = "Toyota",
                Model = "Corolla",
                EngineCapacity = 1.8m,
                Year = 2022,
                Vin = "12345VIN"
            };


            await _carService.AddCarAsync(carModel);

       
            _repositoryMock.Verify(repo => repo.AddAsync(It.Is<Car>(c =>
                c.Id == carModel.Id &&
                c.Make == carModel.Make &&
                c.Model == carModel.Model &&
                c.EngineCapacity == carModel.EngineCapacity &&
                c.Year == carModel.Year &&
                c.Vin == carModel.Vin
            )), Times.Once);

            _repositoryMock.Verify(repo => repo.SaveChangesAsync<CarModel>(), Times.Once);
        }



        [Test]
        public void AddCarAsync_ShouldThrowArgumentNullException_WhenCarModelIsNull()
        {
          
            CarModel carModel = null;

          
            var exception = Assert.ThrowsAsync<ArgumentNullException>(() => _carService.AddCarAsync(carModel));
            Assert.That(exception.ParamName, Is.EqualTo("carModel"));

           
            _repositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Car>()), Times.Never);
            _repositoryMock.Verify(repo => repo.SaveChangesAsync<CarModel>(), Times.Never);

        }



        [Test]
        public async Task GetCarByIdAsync_ShouldReturnCarModel_WhenCarExists()
        {
          
            int carId = 1;
            var car = new Car
            {
                Id = carId,
                Make = "Toyota",
                Model = "Corolla",
                Year = 2022,
                EngineCapacity = 1.8m,
                Vin = "12345VIN"
            };

            _repositoryMock.Setup(repo => repo.GetByIdAsync<Car>(carId)).ReturnsAsync(car);

        
            var result = await _carService.GetCarByIdAsync(carId);

          
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(car.Id));
            Assert.That(result.Make, Is.EqualTo(car.Make));
            Assert.That(result.Model, Is.EqualTo(car.Model));
            Assert.That(result.Year, Is.EqualTo(car.Year));
            Assert.That(result.EngineCapacity, Is.EqualTo(car.EngineCapacity));
            Assert.That(result.Vin, Is.EqualTo(car.Vin));

            _repositoryMock.Verify(repo => repo.GetByIdAsync<Car>(carId), Times.Once);
        }




        [Test]
        public async Task GetCarByIdAsync_ShouldReturnNull_WhenCarDoesNotExist()
        {
          
            int carId = 1;
            _repositoryMock.Setup(repo => repo.GetByIdAsync<Car>(carId)).ReturnsAsync((Car)null);

       
            var result = await _carService.GetCarByIdAsync(carId);

          
            Assert.That(result, Is.Null);


            _repositoryMock.Verify(repo => repo.GetByIdAsync<Car>(carId), Times.Once);

        }




        [Test]
        public async Task UpdateCarAsync_ShouldUpdateCar_WhenCarExists()
        {
            

            var carId = 1;
            var existingCar = new Car
            {
                Id = carId,
                Make = "OldMake",
                Model = "OldModel",
                Year = 2020,
                EngineCapacity = 1.5m,
                Vin = "OLDVIN"
            };

            var updatedCarModel = new CarModel
            {
                Id = carId,
                Make = "NewMake",
                Model = "NewModel",
                Year = 2022,
                EngineCapacity = 2.0m,
                Vin = "NEWVIN"
            };


            _repositoryMock.Setup(repo => repo.GetByIdAsync<Car>(carId)).ReturnsAsync(existingCar);

          
            await _carService.UpdateCarAsync(updatedCarModel);

        
            Assert.That(existingCar.Make, Is.EqualTo(updatedCarModel.Make));
            Assert.That(existingCar.Model, Is.EqualTo(updatedCarModel.Model));
            Assert.That(existingCar.Year, Is.EqualTo(updatedCarModel.Year));
            Assert.That(existingCar.EngineCapacity, Is.EqualTo(updatedCarModel.EngineCapacity));
            Assert.That(existingCar.Vin, Is.EqualTo(updatedCarModel.Vin));

            _repositoryMock.Verify(repo => repo.SaveChangesAsync<Car>(), Times.Once);

        }



        [Test]
        public async Task UpdateCarAsync_ShouldNotCallSaveChanges_WhenCarDoesNotExist()
        {
            

            var carId = 1;
            var carModel = new CarModel
            {
                Id = carId,
                Make = "NewMake",
                Model = "NewModel",
                Year = 2022,
                EngineCapacity = 2.0m,
                Vin = "NEWVIN"
            };

            _repositoryMock.Setup(repo => repo.GetByIdAsync<Car>(carId)).ReturnsAsync((Car)null);


         
            await _carService.UpdateCarAsync(carModel);

      

            _repositoryMock.Verify(repo => repo.SaveChangesAsync<Car>(), Times.Never);
        }


        [Test]
        public async Task DeleteCarAsync_ShouldCallDeleteAndSaveChanges_WhenCarExists()
        {
            
            var carId = 1;

           
            await _carService.DeleteCarAsync(carId);

         
            _repositoryMock.Verify(repo => repo.DeleteAsync<Car>(carId), Times.Once);
            _repositoryMock.Verify(repo => repo.SaveChangesAsync<Car>(), Times.Once);

        }



        [Test]
        public async Task DeleteCarAsync_ShouldNotThrowException_WhenCarDoesNotExist()
        {
           
            var carId = 1;

          
            _repositoryMock.Setup(repo => repo.DeleteAsync<Car>(carId)).Verifiable();

            
            Assert.DoesNotThrowAsync(() => _carService.DeleteCarAsync(carId));

           
            _repositoryMock.Verify(repo => repo.DeleteAsync<Car>(carId), Times.Once);
            _repositoryMock.Verify(repo => repo.SaveChangesAsync<Car>(), Times.Once);

        }



    }
}
