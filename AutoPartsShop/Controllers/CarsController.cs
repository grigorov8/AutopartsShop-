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

        // Метод за извличане на марките автомобили
        [HttpGet("Get-makes")]
        public async Task<IActionResult> GetMakes()
        {
            string url = "https://www.carqueryapi.com/api/0.3/?cmd=getMakes"; // Заявка за марките

            // Извършване на GET заявка към външния API
            var response = await _httpClient.GetStringAsync(url);

            // Връщаме отговор в JSON формат
            return Ok(response);
        }

        // Метод за извличане на моделите на определена марка
        [HttpGet("get-models/{make}")]
        public async Task<IActionResult> GetModels(string make)
        {
            string url = $"https://www.carqueryapi.com/api/0.3/?cmd=getModels&make={make}"; // Заявка за моделите на марка

            var response = await _httpClient.GetStringAsync(url);

            return Ok(response);
        }

        // Метод за извличане на години за определена марка и модел
        [HttpGet("get-years")]
        public async Task<IActionResult> GetYears(string make, string model)
        {
            string url = $"https://www.carqueryapi.com/api/0.3/?cmd=getYears&make={make}&model={model}"; // Заявка за години на марка и модел

            var response = await _httpClient.GetStringAsync(url);

            return Ok(response);
        }

        // Метод за извличане на наличните варианти за даден модел
        [HttpGet("get-trims")]
        public async Task<IActionResult> GetTrims(string make, string model, string year)
        {
            string url = $"https://www.carqueryapi.com/api/0.3/?cmd=getTrims&make={make}&model={model}&year={year}"; // Заявка за варианти на модел

            var response = await _httpClient.GetStringAsync(url);

            return Ok(response);
        }
    }
}
