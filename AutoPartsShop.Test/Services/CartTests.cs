using AutoPartsShop.Core.Services;
using AutoPartsShop.Infrastructure.Database.Common;
using AutoPartsShop.Infrastructure.Database.Models;
using Moq;
using NUnit.Framework;



namespace AutoPartsShop.Test.Services
{


    [TestFixture]
    public class CartTests
    {


        private Mock<IRepository> _repositoryMock;
        private CartService _cartService;



        [SetUp]
        public void SetUp()
        {

            _repositoryMock = new Mock<IRepository>();
            _cartService = new CartService(_repositoryMock.Object);

        }



        [Test]
        public void AddToCartAsync_ShouldThrowException_WhenProductNotFound()
        {

            var userId = "testUser";
            var productId = 1;
            var quantity = 1;
            _repositoryMock.Setup(r => r.GetByIdAsync<Product>(productId)).ReturnsAsync((Product)null);



            var ex = Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await _cartService.AddToCartAsync(userId, productId, null, quantity));
            Assert.That(ex.Message, Is.EqualTo("Не съществува достатъчно количество от този продукт."));


        }



        [Test]
        public void AddToCartAsync_ShouldThrowException_WhenProductStockNotEnough()
        {

            var userId = "testUser";
            var productId = 1;
            var quantity = 10;
            var product = new Product { StockQuantity = 5 };
            _repositoryMock.Setup(r => r.GetByIdAsync<Product>(productId)).ReturnsAsync(product);


            var ex = Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await _cartService.AddToCartAsync(userId, productId, null, quantity));
            Assert.That(ex.Message, Is.EqualTo("Не съществува достатъчно количество от този продукт."));


        }




        




    }


}
