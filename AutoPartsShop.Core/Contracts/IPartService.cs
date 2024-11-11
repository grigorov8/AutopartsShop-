using AutoPartsShop.Core.Models;
using AutoPartsShop.Infrastructure.Database.Common;


namespace AutoPartsShop.Core.Services
{
    public interface IPartService 
    {

         Task<List<PartModel>> SearchPartsAsync(string partNumber);

      //   Task<List<PartSearchByCarModel>> SearchPartsByCarAsync(string Make, string Model, int Year, decimal Displacement);






    }


}
