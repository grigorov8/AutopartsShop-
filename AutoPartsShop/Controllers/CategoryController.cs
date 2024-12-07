using AutoPartsShop.Core.Contracts;
using AutoPartsShop.Core.Models;
using Microsoft.AspNetCore.Mvc;
using AutoPartsShop.Infrastructure.Database.Models;


namespace AutoPartsShop.Controllers
{

    public class CategoryController : Controller
    {

        private readonly ICategoryService _categoryService;


        public CategoryController(ICategoryService categoryService)
        {

            _categoryService = categoryService;

        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();

            
            if (categories == null || !categories.Any())
            {
                return View("NoCategories");
            }

            return View(categories);  
        }


        public async Task<IActionResult> CategoryParts(int categoryId)
        {
            var parts = await _categoryService.GetPartsByCategoryIdAsync(categoryId);

           
           

            return View(parts);
        }



    }


}
