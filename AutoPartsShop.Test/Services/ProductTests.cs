using AutoPartsShop.Core.Models;
using AutoPartsShop.Core.Services;
using AutoPartsShop.Infrastructure.Database.Common;
using AutoPartsShop.Infrastructure.Database.Models;
using Moq;
using NUnit.Framework;


namespace AutoPartsShop.Test.Services
{


    [TestFixture]
    public class ProductTests
    {


        private Mock<IRepository> _repositoryMock;
        private ProductService _productService;



        [SetUp]
        public void SetUp()
        {

            _repositoryMock = new Mock<IRepository>();
            _productService = new ProductService(_repositoryMock.Object);

        }



        [Test]
        public void AddProductAsync_ShouldThrowArgumentNullException_WhenProductModelIsNull()
        {
            
            ProductModel productModel = null;

           
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _productService.AddProductAsync(productModel));

        }



        [Test]
        public async Task UpdateProductAsync_ShouldNotUpdateProduct_WhenProductDoesNotExist()
        {
           

            var productModel = new ProductModel
            {
                Id = 9, 
                Name = "Non-Existent Product",
                ProductNumber = "P99",
                Price = 200,
                Description = "Non-existent product",
                Manufacturer = "Unknown Manufacturer",
                StockQuantity = 0,
                SelectedCategoryId = 3
            };

           

            _repositoryMock.Setup(repo => repo.GetByIdAsync<Product>(productModel.Id)).ReturnsAsync((Product)null);

      
            await _productService.UpdateProductAsync(productModel);

           
            
            _repositoryMock.Verify(repo => repo.SaveChangesAsync<Product>(), Times.Never);


        }



        [Test]
        public async Task GetProductByIdAsync_ShouldReturnProduct_WhenProductExists()
        {
           

            var productId = 1;
            var expectedProduct = new Product
            {
                Id = productId,
                Name = "Test Product",
                ProductNumber = "P12345",
                Price = 100.0m,
                Description = "Test Product Description",
                Manufacturer = "Test Manufacturer",
                StockQuantity = 10
            };


          
            _repositoryMock.Setup(repo => repo.GetByIdAsync<Product>(productId)).ReturnsAsync(expectedProduct);

            
            var result = await _productService.GetProductByIdAsync(productId);

           
            Assert.That(result, Is.Not.Null);

           
            Assert.That(result.Id, Is.EqualTo(expectedProduct.Id));
            Assert.That(result.Name, Is.EqualTo(expectedProduct.Name));
            Assert.That(result.ProductNumber, Is.EqualTo(expectedProduct.ProductNumber));
            Assert.That(result.Price, Is.EqualTo(expectedProduct.Price));
            Assert.That(result.Description, Is.EqualTo(expectedProduct.Description));
            Assert.That(result.Manufacturer, Is.EqualTo(expectedProduct.Manufacturer));
            Assert.That(result.StockQuantity, Is.EqualTo(expectedProduct.StockQuantity));


        }



        [Test]
        public async Task GetProductByIdAsync_ShouldReturnNull_WhenProductDoesNotExist()
        {
            
            var productId = 19; 

           
            _repositoryMock.Setup(repo => repo.GetByIdAsync<Product>(productId)).ReturnsAsync((Product)null);

            
            var result = await _productService.GetProductByIdAsync(productId);

          
            Assert.That(result, Is.Null);


        }


        [Test]
        public async Task DeleteProductAsync_ShouldNotDelete_WhenProductDoesNotExist()
        {
           
            var productId = 20;

           
            _repositoryMock.Setup(repo => repo.GetByIdAsync<Product>(productId)).ReturnsAsync((Product)null);

           
            await _productService.DeleteProductAsync(productId);

            
            _repositoryMock.Verify(repo => repo.DeleteAsync<Product>(productId), Times.Never);
            _repositoryMock.Verify(repo => repo.SaveChangesAsync<Product>(), Times.Never);


        }





    }

}
