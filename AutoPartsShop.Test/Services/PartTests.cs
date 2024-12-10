using AutoPartsShop.Core.Models;
using AutoPartsShop.Core.Services;
using AutoPartsShop.Infrastructure.Database.Common;
using AutoPartsShop.Infrastructure.Database.Models;
using Moq;
using NUnit.Framework;



namespace AutoPartsShop.Test.Services
{


    [TestFixture]
    public class PartTests
    {



        private Mock<IRepository> _repositoryMock;
        private PartService _partService;


        [SetUp]
        public void SetUp()
        {

            _repositoryMock = new Mock<IRepository>();
            _partService = new PartService(_repositoryMock.Object);

        }


        [Test]
        public async Task AddPartAsync_ShouldAddPart_WhenPartModelIsValid()
        {
           

            var partModel = new PartModel
            {
                Id = 1,
                Name = "Brake Pad",
                PartNumber = "BP123",
                Price = 100.50m,
                Description = "High quality brake pad",
                Manufacturer = "AutoMax",
                Stock = 50,
                SelectedCategoryId = 2
            };

         
            await _partService.AddPartAsync(partModel);

          
            _repositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Part>()), Times.Once);
            _repositoryMock.Verify(repo => repo.SaveChangesAsync<Part>(), Times.Once);

        }

        
        [Test]
        public void AddPartAsync_ShouldThrowArgumentNullException_WhenPartModelIsNull()
        {
            

            Assert.ThrowsAsync<ArgumentNullException>(async () => await _partService.AddPartAsync(null));

        }

      


        [Test]
        public void AddPartAsync_ShouldThrowException_WhenRepositoryFails()
        {
       

            var partModel = new PartModel
            {
                Id = 1,
                Name = "Brake Pad",
                PartNumber = "BP123",
                Price = 100.50m,
                Description = "High quality brake pad",
                Manufacturer = "AutoMax",
                Stock = 50,
                SelectedCategoryId = 2
            };

            
            _repositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Part>())).ThrowsAsync(new Exception("Repository failure"));

           
            Assert.ThrowsAsync<Exception>(async () => await _partService.AddPartAsync(partModel));
        }



        [Test]
        public async Task DeletePartAsync_ShouldDeletePart_WhenIdIsValid()
        {
           
            int partId = 1;
            var part = new Part { Id = partId, Name = "Test Part" };

         
            _repositoryMock.Setup(repo => repo.GetByIdAsync<Part>(partId)).ReturnsAsync(part);

            
            await _partService.DeletePartAsync(partId);

            

            _repositoryMock.Verify(repo => repo.DeleteAsync<Part>(partId), Times.Once);
            _repositoryMock.Verify(repo => repo.SaveChangesAsync<Part>(), Times.Once);


        }



        [Test]
        public async Task DeletePartAsync_ShouldNotCallDelete_WhenPartDoesNotExist()
        {
            
            int partId = 999;  

            
            _repositoryMock.Setup(repo => repo.GetByIdAsync<Part>(partId)).ReturnsAsync((Part)null);

           
            await _partService.DeletePartAsync(partId);

          
            _repositoryMock.Verify(repo => repo.DeleteAsync<Part>(It.IsAny<int>()), Times.Never);
            _repositoryMock.Verify(repo => repo.SaveChangesAsync<Part>(), Times.Never);

        }



        [Test]
        public async Task GetPartByIdAsync_ShouldReturnPartModel_WhenPartExists()
        {
           

            int partId = 1;
            var part = new Part
            {
                Id = partId,
                Name = "Test Part",
                PartNumber = "12345",
                Price = 100,
                Description = "Test part description",
                Manufacturer = "Test Manufacturer",
                Stock = 10
            };

           
            _repositoryMock.Setup(repo => repo.GetByIdAsync<Part>(partId)).ReturnsAsync(part);

       
            var result = await _partService.GetPartByIdAsync(partId);

           
            Assert.That(result, Is.Not.Null); 
            Assert.That(result.Id, Is.EqualTo(partId));  
            Assert.That(result.Name, Is.EqualTo("Test Part")); 
            Assert.That(result.PartNumber, Is.EqualTo("12345"));  
            Assert.That(result.Price, Is.EqualTo(100));  
            Assert.That(result.Description, Is.EqualTo("Test part description"));  
            Assert.That(result.Manufacturer, Is.EqualTo("Test Manufacturer"));  
            Assert.That(result.Stock, Is.EqualTo(10));  

        }



        [Test]
        public async Task GetPartByIdAsync_ShouldReturnNull_WhenPartDoesNotExist()
        {
           
            int partId = 999;  

           
            _repositoryMock.Setup(repo => repo.GetByIdAsync<Part>(partId)).ReturnsAsync((Part)null);

           
            var result = await _partService.GetPartByIdAsync(partId);

            
            Assert.That(result, Is.Null);  

        }




        [Test]
        public async Task UpdatePartAsync_ShouldNotUpdatePart_WhenPartDoesNotExist()
        {
            

            var partId = 999; 
            var partModel = new PartModel
            {
                Id = partId,
                Name = "Updated Part",
                PartNumber = "54321",
                Price = 150,
                Description = "Updated part description",
                Manufacturer = "Updated Manufacturer",
                Stock = 20,
                SelectedCategoryId = 1
            };

            

            _repositoryMock.Setup(repo => repo.GetByIdAsync<Part>(partId)).ReturnsAsync((Part)null);

            
            await _partService.UpdatePartAsync(partModel);

            
           
            _repositoryMock.Verify(repo => repo.SaveChangesAsync<Part>(), Times.Never);

        }





    }


}
