using AutoPartsShop.Core.Contracts;
using AutoPartsShop.Core.Models;
using AutoPartsShop.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace AutoPartsShop.Web.Controllers
{


    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IProductService _productService;
        private readonly IPartService _partService;


        public CartController(ICartService cartService, IProductService productService, IPartService partService)
        {
            _cartService = cartService;
            _productService = productService;
            _partService = partService;
        }



        public async Task<IActionResult> ViewCart()
        {
           
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/Identity/Account/Login");
            }

           
            var userId = User.Identity.Name;

          
            var cartItems = await _cartService.GetCartItemsAsync(userId);
           

            if (cartItems == null || !cartItems.Any())
            {
                
                return View();
            }

           
            var cartViewModel = new CartViewModel
            {

              
                Products = cartItems.Where(ci => ci.ProductId != null)
                    .Select(ci => new ProductModel
                    {
                        Id = ci.Product.Id,
                        Name = ci.Product.Name,
                        Price = ci.Product.Price,
                        ProductNumber = ci.Product.ProductNumber,
                        StockQuantity = ci.Quantity
                    }).ToList(),

              
                Parts = cartItems.Where(ci => ci.PartId != null)
                    .Select(ci => new PartModel
                    {
                        Id = ci.Part.Id,
                        Name = ci.Part.Name,
                        Price = ci.Part.Price,
                        PartNumber = ci.Part.PartNumber,
                        Stock = ci.Quantity
                    }).ToList(),

               
                TotalPrice = cartItems.Sum(ci =>
                    (ci.Product?.Price ?? 0) * ci.Quantity +
                    (ci.Part?.Price ?? 0) * ci.Quantity)
            };

          
            return View(cartViewModel);

        }




        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddToCart(int? productId, int? partId, int quantity)
        {

            var userId = User.Identity.Name;

            try
            {

                await _cartService.AddToCartAsync(userId, productId, partId, quantity);
                TempData["Success"] = "Продуктът беше успешно добавен в количката!";

            }
            catch (InvalidOperationException ex)
            {

                TempData["Error"] = ex.Message; 

            }

            return RedirectToAction("ViewCart");

        }




        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int? productId, int? partId)
        {


            if (productId == null && partId == null)
            {
                return BadRequest("ProductId or PartId must be provided.");
            }

            else
            {
                await _cartService.RemoveFromCartByProductOrPartIdAsync(productId, partId);
                return RedirectToAction("ViewCart");
            }
                          
                        
            
        }





    }
}
