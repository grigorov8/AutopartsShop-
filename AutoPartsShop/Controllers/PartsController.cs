
using Microsoft.AspNetCore.Mvc;
using AutoPartsShop.Core.Services;


namespace AutoPartsShop.Controllers
{

    public class PartsController : Controller
    {

        private readonly IPartService _partService;


        public PartsController(IPartService partService)
        {

            _partService = partService;

        }



        public async Task<IActionResult> PartSearch(string partNumber)
        {

                 
            var parts = await _partService.SearchPartsAsync(partNumber);

            if (parts == null || !parts.Any())
            {

                ViewBag.Message = $"Part with number '{partNumber}' not found.";
                return View();

            }

            return View(parts);

        }


    }
}