using Microsoft.AspNetCore.Mvc;
using AutoPartsShop.Core.Services;
using AutoPartsShop.Core.Models;
using AutoPartsShop.Infrastructure.Database.Models;


namespace AutoPartsShop.Controllers
{

    
    public class PartsController : Controller
    {


        private readonly IPartService _partService;


        public PartsController(IPartService partService)
        {

            _partService = partService;

        }


        [HttpGet]
        public async Task<IActionResult> PartSearch(string partNumber)
        {
     
            var parts = await _partService.SearchPartsAsync(partNumber);

            if (parts == null || !parts.Any())
            {
  
                return View();

            }

            return View(parts);

        }


        [HttpGet]
        public async Task<IActionResult> ManageParts()
        {

            var parts = await _partService.GetAllPartsAsync(); 

            return View(parts); 

        }


        [HttpGet]
        public async Task<IActionResult> AddPartAsync()
        {

            var partModel = new PartModel();

           
            partModel.Categories = (await _partService.GetAllCategoriesAsync()).ToList();

            return View(partModel); 

        }

        [HttpPost]
        public async Task<IActionResult> AddPart(PartModel partModel)
        {

            if (ModelState.IsValid)
            {

                await _partService.AddPartAsync(partModel);
                return RedirectToAction(nameof(ManageParts));

            }


            return View(partModel);

        }



        [HttpGet]
        public async Task<IActionResult> EditPart(int id)
        {
            var part = await _partService.GetPartByIdAsync(id); 
            if (part == null)
            {
                return NotFound();
            }
            return View(part); 
        }

     
        [HttpPost]
        public async Task<IActionResult> EditPart(PartModel partModel)
        {
            if (ModelState.IsValid)
            {
                await _partService.UpdatePartAsync(partModel); 
                return RedirectToAction(nameof(ManageParts)); 
            }
            return View(partModel);
        }

        
        [HttpPost]
        public async Task<IActionResult> DeletePart(int id)
        {
            var part = await _partService.GetPartByIdAsync(id); 
            if (part == null)
            {
                return NotFound();
            }

            await _partService.DeletePartAsync(id); 
            return RedirectToAction(nameof(ManageParts)); 
        }


    }

}