using AutoPartsShop.Infrastructure.Database.Models;



namespace AutoPartsShop.Core.Contracts
{
    public interface ICategoryService
    {

        Task<IEnumerable<Category>> GetAllCategoriesAsync();

     
        Task<IEnumerable<Part>> GetPartsByCategoryIdAsync(int categoryId);

    }




}


