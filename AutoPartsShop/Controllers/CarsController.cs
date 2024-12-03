using AutoPartsShop.Core.Contracts;
using AutoPartsShop.Core.Models;
using AutoPartsShop.Core.Services;
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



        [HttpGet]
        public async Task<IActionResult> ManageCars()
        {

            var cars = await _carService.GetAllCarsAsync();


            return View(cars);

        }


        [HttpGet]
        public IActionResult AddCar()
        {

            var carModel = new CarModel();


            return View(carModel);

        }


        [HttpPost]
        public async Task<IActionResult> AddCar(CarModel carModel)
        {

            if (ModelState.IsValid)
            {

                await _carService.AddCarAsync(carModel);
                return RedirectToAction(nameof(ManageCars));

            }


            return View(carModel);

        }


        [HttpGet]
        public async Task<IActionResult> EditCar(int id)
        {

            var car = await _carService.GetCarByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }


        [HttpPost]
        public async Task<IActionResult> EditCar(CarModel carModel)
        {
            if (ModelState.IsValid)
            {
                await _carService.UpdateCarAsync(carModel);
                return RedirectToAction(nameof(ManageCars));
            }
            return View(carModel);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var part = await _carService.GetCarByIdAsync(id);
            if (part == null)
            {
                return NotFound();
            }

            await _carService.DeleteCarAsync(id);
            return RedirectToAction(nameof(ManageCars));
        }



    }


}
