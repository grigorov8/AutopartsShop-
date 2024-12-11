using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;


namespace AutoPartsShop.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {



        private readonly HttpClient _httpClient;



        public CarController(HttpClient httpClient)
        {

            _httpClient = httpClient;

        }


        

        [HttpGet("Get-makes")]
        public async Task<IActionResult> GetMakes()
        {

            string url = "https://www.carqueryapi.com/api/0.3/?cmd=getMakes";

            var response = await _httpClient.GetStringAsync(url);

            return Ok(response); 

        }

      

        [HttpGet("get-models/{make}")]
        public async Task<IActionResult> GetModels(string make)
        {

            string url = $"https://www.carqueryapi.com/api/0.3/?cmd=getModels&make={make}";

            var response = await _httpClient.GetStringAsync(url);

            return Ok(response); 
        }

       
        [HttpGet("get-years")]
        public async Task<IActionResult> GetYears(string make, string model)
        {

            string url = $"https://www.carqueryapi.com/api/0.3/?cmd=getYears&make={make}&model={model}";
            var response = await _httpClient.GetStringAsync(url);

            return Ok(response); 


        }


      
        [HttpGet("get-engine-sizes")]
        public async Task<IActionResult> GetEngineSizes(string make, string model, string year)
        {
            string url = $"https://www.carqueryapi.com/api/0.3/?cmd=getTrims&make={make}&model={model}&year={year}";
            var response = await _httpClient.GetStringAsync(url);

            return Ok(response); 

        }

       

        [HttpGet("get-model")]
        public async Task<IActionResult> GetCarDetails(string model)
        {
            string url = $"https://www.carqueryapi.com/api/0.3/?cmd=getModel&model={model}";

            var response = await _httpClient.GetStringAsync(url);

            return Ok(response); 
        }


    }
}
