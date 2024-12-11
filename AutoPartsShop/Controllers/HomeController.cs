using AutoPartsShop.Core.Contracts;
using AutoPartsShop.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;



namespace AutoPartsShop.Controllers
{
    public class HomeController : Controller
    {


        private readonly ICategoryService _categoryService;

        public HomeController(ICategoryService categoryService)
        {

            _categoryService = categoryService;

        }


        public async Task<IActionResult> Index()
        {

            var categories = await _categoryService.GetAllCategoriesAsync();
            if (categories == null || !categories.Any())
            {
                
                return View(new List<CategoryModel>());
            }

            var categoryModels = categories.Select(c => new CategoryModel
            {
                Id = c.Id,
                Name = c.Name

            }).ToList();

            return View(categoryModels); 

        }

        public IActionResult CarSearch()
        {
            return View();
        }


        public IActionResult Error(int? statusCode)
        {
           

            if (statusCode == 404)
            {

                return View("Error404");

            }
            else
            {
                return View("Error500"); 
            }


        }


       


    }
}
