using AutoPartsShop.Infrastructure.Database.Models;
using AutoPartsShop.Core.Services;
using AutoPartsShop.Core.Models;

namespace AutoPartsShop.Core.Contracts
{
    public interface ICategoryService
    {

        Task<IEnumerable<Category>> GetAllCategoriesAsync();

     
        Task<IEnumerable<Part>> GetPartsByCategoryIdAsync(int categoryId);

    }




}


