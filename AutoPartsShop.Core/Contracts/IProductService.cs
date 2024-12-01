using AutoPartsShop.Core.Models;
using AutoPartsShop.Infrastructure.Database.Models;

namespace AutoPartsShop.Core.Contracts
{

    public interface IProductService
    {

        Task<IEnumerable<ProductModel>> GetAllProductsAsync();

        Task AddProductAsync(ProductModel product);

        Task<IEnumerable<Category>> GetAllCategoriesAsync();

        Task UpdateProductAsync(ProductModel product);

        Task<ProductModel> GetProductByIdAsync(int id);

        Task DeleteProductAsync(int id);


    }


}
