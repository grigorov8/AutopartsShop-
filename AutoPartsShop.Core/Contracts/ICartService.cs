using AutoPartsShop.Infrastructure.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPartsShop.Core.Contracts
{
    public interface ICartService
    {


        Task AddToCartAsync(string userId, int? productId, int? partId, int quantity);


        Task RemoveFromCartByProductOrPartIdAsync(int? productId, int? partId);



        Task<List<CartItem>> GetCartItemsAsync(string userId);

       
        Task<decimal> GetTotalPriceAsync(string userId);

      

    }


}
