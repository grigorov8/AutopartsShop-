using AutoPartsShop.Core.Contracts;
using AutoPartsShop.Core.Models;
using AutoPartsShop.Infrastructure.Database.Common;
using Microsoft.EntityFrameworkCore;
using AutoPartsShop.Infrastructure.Database.Models;



namespace AutoPartsShop.Core.Services
{

    public class ProductService : IProductService
    {

        private readonly IRepository _repository;


        public ProductService(IRepository repository)
        {
            _repository = repository;
        }


        public async Task<IEnumerable<ProductModel>> GetAllProductsAsync()
        {


            return await _repository.All<Product>()

            .Select(p => new ProductModel
            {
                Id = p.Id,
                Name = p.Name,
                ProductNumber = p.ProductNumber,
                Price = p.Price,
                Manufacturer = p.Manufacturer,
                Description = p.Description,
                StockQuantity = p.StockQuantity,
            })
            .ToListAsync();
           


        }



        public async Task AddProductAsync(ProductModel productModel)
        {


            if (productModel == null)
            {

                throw new ArgumentNullException(nameof(productModel), "Product model cannot be null.");

            }


            var product = new Product
            {
                Id = productModel.Id,
                Name = productModel.Name,
                ProductNumber = productModel.ProductNumber,
                Price = productModel.Price,
                Description = productModel.Description,
                Manufacturer = productModel.Manufacturer,
                StockQuantity = productModel.StockQuantity,
                CategoryId = productModel.SelectedCategoryId   
            };

            await _repository.AddAsync(product);
            await _repository.SaveChangesAsync<Product>();

        }



        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {

            return await _repository.All<Category>().ToListAsync();

        }


        public async Task UpdateProductAsync(ProductModel productModel)
        {

            var product = await _repository.GetByIdAsync<Product>(productModel.Id);

            if (product != null)
            {
                product.Name = productModel.Name;
                product.ProductNumber = productModel.ProductNumber;
                product.Price = productModel.Price;
                product.Description = productModel.Description;
                product.Manufacturer = productModel.Manufacturer;
                product.StockQuantity = productModel.StockQuantity;

                await _repository.SaveChangesAsync<Product>();
            }



        }

      

        public async Task<ProductModel> GetProductByIdAsync(int id)
        {

            var product = await _repository.GetByIdAsync<Product>(id);

            if (product != null)
            {
                return new ProductModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    ProductNumber = product.ProductNumber,
                    Price = product.Price,
                    Description = product.Description,
                    Manufacturer = product.Manufacturer,
                    StockQuantity = product.StockQuantity,

                };
            }

            return null;
        }



        public async Task DeleteProductAsync(int id)
        {

            var product = await _repository.GetByIdAsync<Product>(id);

            if (product != null)
            {

                await _repository.DeleteAsync<Product>(id);
                await _repository.SaveChangesAsync<Product>();

            }


        }






    }



}
