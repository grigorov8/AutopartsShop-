using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;



namespace AutoPartsShop.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
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
