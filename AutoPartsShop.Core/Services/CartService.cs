using AutoPartsShop.Core.Contracts;
using AutoPartsShop.Infrastructure.Database.Common;
using AutoPartsShop.Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore;



namespace AutoPartsShop.Core.Services
{

    public class CartService : ICartService
    {

        private readonly IRepository _repository;


        public CartService(IRepository repository)
        {
            _repository = repository;
        }




        public async Task AddToCartAsync(string userId, int? productId, int? partId, int quantity)
        {


            if (productId.HasValue)
            {

                var product = await _repository.GetByIdAsync<Product>(productId.Value);

                if (product == null || product.StockQuantity < quantity)
                {
                    throw new InvalidOperationException("Не съществува достатъчно количество от този продукт.");
                }

               
                product.StockQuantity -= quantity;
                await _repository.SaveChangesAsync<Product>();  
            }
            else if (partId.HasValue)
            {

                var part = await _repository.GetByIdAsync<Part>(partId.Value);

                if (part == null || part.Stock < quantity)
                {
                    throw new InvalidOperationException("Не съществува достатъчно количество от тази част.");
                }

               
                part.Stock -= quantity;
                await _repository.SaveChangesAsync<Part>();  
            }


            var existingCartItem = await _repository.All<CartItem>()
                .FirstOrDefaultAsync(ci => ci.UserId == userId &&
                                           (ci.ProductId == productId || ci.PartId == partId));

           
              
                var newCartItem = new CartItem
                {
                    UserId = userId,
                    ProductId = productId,
                    PartId = partId,
                    Quantity = quantity
                };

                await _repository.AddAsync(newCartItem);
            

            await _repository.SaveChangesAsync<CartItem>();

        }




        public async Task RemoveFromCartByProductOrPartIdAsync(int? productId, int? partId)
        {


            if (productId == null && partId == null)
            {
                throw new ArgumentException("Either ProductId or PartId must be provided.");
            }

            
            var cartItem = await _repository.All<CartItem>()
                .FirstOrDefaultAsync(ci =>
                    (productId.HasValue && ci.ProductId == productId.Value) ||
                    (partId.HasValue && ci.PartId == partId.Value));

            if (cartItem == null)
            {
                throw new InvalidOperationException("Item not found in the cart.");
            }

            
            if (cartItem.ProductId.HasValue)
            {
                var product = await _repository.GetByIdAsync<Product>(cartItem.ProductId.Value);
                if (product != null)
                {
                    product.StockQuantity += cartItem.Quantity;
                    await _repository.SaveChangesAsync<Product>();
                }
            }
            else if (cartItem.PartId.HasValue)
            {
                var part = await _repository.GetByIdAsync<Part>(cartItem.PartId.Value);
                if (part != null)
                {
                    part.Stock += cartItem.Quantity;
                    await _repository.SaveChangesAsync<Part>();
                }
            }

           
            await _repository.DeleteAsync<CartItem>(cartItem.Id);
            await _repository.SaveChangesAsync<CartItem>();


        }






        public async Task<List<CartItem>> GetCartItemsAsync(string userId)
        {

            var cartItems = await _repository.All<CartItem>()
                .Where(ci => ci.UserId == userId)
                .Include(ci => ci.Product) 
                .Include(ci => ci.Part)    
                .ToListAsync();

            return cartItems;

        }

        
        public async Task<decimal> GetTotalPriceAsync(string userId)
        {
            var cartItems = await GetCartItemsAsync(userId);

            decimal totalPrice = 0;

            foreach (var item in cartItems)
            {
                decimal itemPrice = (item.Product?.Price ?? 0) * item.Quantity +
                                    (item.Part?.Price ?? 0) * item.Quantity;

                totalPrice += itemPrice;
            }

            return totalPrice;
        }





    }
}
