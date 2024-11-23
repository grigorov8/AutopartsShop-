using System.ComponentModel.DataAnnotations;
using Shared.ValidationConstants;


namespace AutoPartsShop.Core.Models
{
    public class CarModel
    {

        public int Id { get; set; }
        
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public decimal EngineCapacity { get; set; }
        public string Image { get; set; } = string.Empty;

        [StringLength(CarValidationConstants.VinLenght)]
        public string Vin { get; set; } = string.Empty;

        public List<PartModel> Parts { get; set; } = new List<PartModel>();

    }
}
