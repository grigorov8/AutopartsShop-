using AutoPartsShop.Core.Models;
using AutoPartsShop.Infrastructure.Database.Models;


namespace AutoPartsShop.Core.Services
{
    public interface IPartService
    {

        Task<List<PartModel>> SearchPartsAsync(string partNumber);

        Task<IEnumerable<PartModel>> GetAllPartsAsync();
        Task<PartModel> GetPartByIdAsync(int id);
        Task AddPartAsync(PartModel part);
        Task UpdatePartAsync(PartModel part);
        Task DeletePartAsync(int id);

        Task<IEnumerable<Category>> GetAllCategoriesAsync();

      


    }

}
