using Microsoft.AspNetCore.Mvc;



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
            else if (statusCode == 401 || statusCode == 403)
            {

                return View("Error403");

            }
            else
            {
                return View("Error500");
            }
            

        }


       


    }
}
