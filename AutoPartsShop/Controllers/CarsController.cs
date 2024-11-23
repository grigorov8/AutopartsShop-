using AutoPartsShop.Core.Contracts;
using Microsoft.AspNetCore.Mvc;


namespace AutoPartsShop.Controllers
{

    public class CarsController : Controller
    {


        private readonly ICarService _carService;


        public CarsController(ICarService carService)
        {

            _carService = carService;

        }


        [HttpGet]
        public async Task<IActionResult> SearchByVin(string vin)
        {

            var car = await _carService.SearchCarByVin(vin);


            if (car == null)
            {
                TempData["ErrorMessage"] = "Car not found!";
                return RedirectToAction("Index", "Home");
            }


            return View("CarDetails", car);

        }

       

    }


}
