using AutoPartsShop.Core.Contracts;
using AutoPartsShop.Core.Models;
using Microsoft.AspNetCore.Mvc;
using X.PagedList.Extensions;


namespace AutoPartsShop.Controllers
{
    public class ProductController : Controller
    {


        private readonly IProductService _productService;


        public ProductController(IProductService productService)
        {

            _productService = productService;

        }


        [HttpGet]
        public async Task<IActionResult> ProductSearch(int page = 1, int pageSize = 10)
        {
           
            var oils = await _productService.GetAllProductsAsync();

            var pagedProducts = oils.ToPagedList(page, pageSize);

            return View(pagedProducts);

        }



        [HttpGet]
        public async Task<IActionResult> ManageProduct()
        {

            var products = await _productService.GetAllProductsAsync();

            return View(products);

        }


        [HttpGet]
        public async Task<IActionResult> AddProductAsync()
        {
            var productModel = new ProductModel();

            productModel.Categories = (await _productService.GetAllCategoriesAsync()).ToList();

            return View(productModel);

        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductModel productModel)
        {

            if (ModelState.IsValid)
            {

                await _productService.AddProductAsync(productModel);
                return RedirectToAction(nameof(ManageProduct));

            }


            return View(productModel);

        }



        [HttpGet]
        public async Task<IActionResult> EditProduct(int id)
        {

            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }


        [HttpPost]
        public async Task<IActionResult> EditProduct(ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                await _productService.UpdateProductAsync(productModel);
                return RedirectToAction(nameof(ManageProduct));
            }
            return View(productModel);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            await _productService.DeleteProductAsync(id);

            return RedirectToAction(nameof(ManageProduct));

        }





    }


}
